using CadastroC_;
using CadastroC_.Properties;
using CadastroLogin;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace CadastroLogin
{
    public partial class FrmLogin : System.Windows.Forms.Form
    {
        private bool senhaVisivel = false;

        private int tentativasRestantes = 3;
        private DateTime? tempoBloqueio = null;
        private string usuarioBloqueado = "";
        private const int TEMPO_BLOQUEIO_SEGUNDOS = 60;

        private Timer timerBloqueio = new Timer();

        private string caminhoBloqueio = Path.Combine(Application.StartupPath, "bloqueio.txt");

        public FrmLogin()
        {
            InitializeComponent();

            // configuração de timer de bloqueio para excesso de tentativas
            timerBloqueio.Interval = 1000; 
            timerBloqueio.Tick += TimerBloqueio_Tick;
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            // verifica se existe um bloqueio salvo (mesmo após fechar o formulário e reabrir)
            if (File.Exists(caminhoBloqueio))
            {
                string[] dados = File.ReadAllText(caminhoBloqueio).Split('|');
                usuarioBloqueado = dados[0];
                tempoBloqueio = DateTime.Parse(dados[1]);

                if (DateTime.Now < tempoBloqueio.Value)
                {
                    BloquearInterface();
                    timerBloqueio.Start();
                }
                else
                {
                    File.Delete(caminhoBloqueio); // bloqueio expirado
                }

            }
            txtSenha.UseSystemPasswordChar = true;
            btnVerSenha.Image = Resources.iconInvisivel;
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();
            string senha = txtSenha.Text;

            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(senha))
            {
                lblErro.Text = "Preencha usuário e senha.";
                return;
            }

            if (usuarioBloqueado == usuario && tempoBloqueio.HasValue && DateTime.Now < tempoBloqueio.Value)
            {
                BloquearInterface();
                timerBloqueio.Start();
                return;
            }

            ConexaoBD conexaoBD = new ConexaoBD();

            try
            {
                if (conexaoBD.Conectar())
                {
                    string sql = "SELECT senhaHash FROM usuarios WHERE usuario = @usuario LIMIT 1";
                    using (MySqlCommand cmd = new MySqlCommand(sql, conexaoBD.ObterConexao()))
                    {
                        cmd.Parameters.AddWithValue("@usuario", usuario);
                        object resultado = cmd.ExecuteScalar();

                        if (resultado != null)
                        {
                            string senhaHashBanco = resultado.ToString();

                            bool senhaCorreta = Criptografia.VerificarHash(senha, senhaHashBanco);

                            if (senhaCorreta)
                            {
                                tentativasRestantes = 3;
                                usuarioBloqueado = "";

                                if (File.Exists(caminhoBloqueio))
                                    File.Delete(caminhoBloqueio);

                                // abre o formulário principal (menu)
                                FrmMenu frmMenu = new FrmMenu();
                                frmMenu.Show();

                                this.Hide();
                            }
                            else
                            {
                                TratarTentativaIncorreta(usuario);
                            }
                        }
                        else
                        {
                            TratarTentativaIncorreta(usuario);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lblErro.Text = $"Erro: {ex.Message}";

                try
                {
                    // prática de DevOps para registrar Logs de erro no banco de dados
                    Logger.Registrar(txtUsuario.Text, "Tentativa de login", ex.Message);
                }
                catch (Exception logEx)
                {
                    // caso o banco esteja fora do ar, salva localmente
                    System.IO.File.AppendAllText("logs_falha.txt",
                        $"{DateTime.Now} - Falha ao registrar log de login: {logEx.Message}\n");
                }
            }
            finally
            {
                conexaoBD.Desconectar();
            }
        }


        private void TratarTentativaIncorreta(string usuario)
        {
            tentativasRestantes--;

            Logger.Registrar(usuario, "Tentativa de login incorreta",
                $"Usuário ou senha incorretos. Tentativas restantes: {tentativasRestantes}");

            if (tentativasRestantes > 0)
            {
                lblErro.Text = $"Usuário ou senha incorretos. Você tem {tentativasRestantes} tentativas restantes.";
            }
            else
            {
                usuarioBloqueado = usuario;
                tempoBloqueio = DateTime.Now.AddSeconds(TEMPO_BLOQUEIO_SEGUNDOS);
                File.WriteAllText(caminhoBloqueio, $"{usuarioBloqueado}|{tempoBloqueio}");

                lblErro.Text = "Usuário bloqueado por 60 segundos.";
                tentativasRestantes = 3;
                BloquearInterface();
                timerBloqueio.Start();

                Logger.Registrar(usuario, "Bloqueio de login",
                    $"Usuário bloqueado por 60 segundos após tentativas incorretas.");
            }
        }


        private void BloquearInterface()
        {
            txtUsuario.Enabled = false;
            txtSenha.Enabled = false;
            btnLogin.Enabled = false;
            btnVerSenha.Enabled = false;
        }

        private void DesbloquearInterface()
        {
            txtUsuario.Enabled = true;
            txtSenha.Enabled = true;
            btnLogin.Enabled = true;
            btnVerSenha.Enabled = true;
            lblErro.Text = "";
        }

        private void TimerBloqueio_Tick(object sender, EventArgs e)
        {
            if (tempoBloqueio.HasValue)
            {
                int restante = (int)(tempoBloqueio.Value - DateTime.Now).TotalSeconds;

                if (restante > 0)
                {
                    lblErro.Text = $"Usuário bloqueado. Tente novamente em {restante}s.";
                }
                else
                {
                    timerBloqueio.Stop();
                    DesbloquearInterface();
                    usuarioBloqueado = "";
                    tempoBloqueio = null;

                    if (File.Exists(caminhoBloqueio))
                        File.Delete(caminhoBloqueio);

                    lblErro.Text = "";
                }
            }
        }

        private void btnVerSenha_MouseDown(object sender, MouseEventArgs e)
        {
            txtSenha.UseSystemPasswordChar = false;
            btnVerSenha.Image = Resources.iconVisivel;
        }

        private void btnVerSenha_MouseUp(object sender, MouseEventArgs e)
        {
            txtSenha.UseSystemPasswordChar = true;
            btnVerSenha.Image = Resources.iconInvisivel;
        }

        private void lblEsqueciSenha_Click(object sender, EventArgs e)
        {
            FrmEsqueciSenha frmEsqueci = new FrmEsqueciSenha();
            frmEsqueci.ShowDialog(); 
        }
    }
    }

