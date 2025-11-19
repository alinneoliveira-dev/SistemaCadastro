using CadastroC_.Properties;
using CadastroLogin;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CadastroC_
{
    public partial class FrmEsqueciSenha : Form
    {
        public FrmEsqueciSenha()
        {
            InitializeComponent();

            txtNovaSenha.UseSystemPasswordChar = true;
            txtConfirmaSenha.UseSystemPasswordChar = true;

            btnSenha.Image = Resources.iconInvisivel;
            btnVerSenha.Image = Resources.iconInvisivel;
        }



        private void btnSalvarSenha_Click_1(object sender, EventArgs e)
        {
            {
                string usuario = txtUsuarioSenha.Text.Trim();
                string novaSenha = txtNovaSenha.Text;
                string confirmaSenha = txtConfirmaSenha.Text;

                if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(novaSenha) || string.IsNullOrEmpty(confirmaSenha))
                {
                    MessageBox.Show("Preencha todos os campos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (novaSenha != confirmaSenha)
                {
                    MessageBox.Show("As senhas digitadas não coincidem.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                ConexaoBD conexaoBD = new ConexaoBD();

                try
                {
                    if (conexaoBD.Conectar())
                    {
                        // verifica se o usuário existe
                        string sqlVerifica = "SELECT COUNT(*) FROM usuarios WHERE usuario = @usuario";
                        using (MySqlCommand cmdVerifica = new MySqlCommand(sqlVerifica, conexaoBD.ObterConexao()))
                        {
                            cmdVerifica.Parameters.AddWithValue("@usuario", usuario);
                            int count = Convert.ToInt32(cmdVerifica.ExecuteScalar());

                            if (count == 0)
                            {
                                MessageBox.Show("Usuário não encontrado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }

                        // gera hash da nova senha
                        string hashNovaSenha = Criptografia.GerarHashSHA256(novaSenha);

                        // atualiza no banco
                        string sqlAtualiza = "UPDATE usuarios SET senhaHash = @senhaHash WHERE usuario = @usuario";
                        using (MySqlCommand cmdAtualiza = new MySqlCommand(sqlAtualiza, conexaoBD.ObterConexao()))
                        {
                            cmdAtualiza.Parameters.AddWithValue("@senhaHash", hashNovaSenha);
                            cmdAtualiza.Parameters.AddWithValue("@usuario", usuario);
                            cmdAtualiza.ExecuteNonQuery();
                        }

                        MessageBox.Show("Senha alterada com sucesso! Faça login com a nova senha.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        this.Close(); // fecha o formulário e volta para login
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao atualizar senha: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    conexaoBD.Desconectar();
                }
            }
        }

        private void txtUsuarioSenha_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnVoltarLogin_Click_1(object sender, EventArgs e)
        {
            this.Close(); 

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnSenha_MouseDown(object sender, MouseEventArgs e)
        {
            txtNovaSenha.UseSystemPasswordChar = false;
            btnSenha.Image = Resources.iconVisivel; 
        }

        private void btnSenha_MouseUp(object sender, MouseEventArgs e)
        {
            txtNovaSenha.UseSystemPasswordChar = true; 
            btnSenha.Image = Resources.iconInvisivel; 
        }

        private void btnVerSenha_MouseDown(object sender, MouseEventArgs e)
        {
            txtConfirmaSenha.UseSystemPasswordChar = false; 
            btnVerSenha.Image = Resources.iconVisivel; 
        }

        private void btnVerSenha_MouseUp(object sender, MouseEventArgs e)
        {
            txtConfirmaSenha.UseSystemPasswordChar = true; 
            btnVerSenha.Image = Resources.iconInvisivel; 
        }
    }
}
