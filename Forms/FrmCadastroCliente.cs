using CadastroLogin;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace CadastroC_
{
    public partial class FrmCadastroCliente : Form
    {
        private ConexaoBD conexaoBD = new ConexaoBD();

        // variáveis auxiliares
        private int? clienteId = null; //  usado quando for atualizar dados do cliente

        public FrmCadastroCliente()
        {
            InitializeComponent();
        }

        // construtor para editar (recebe dados do cliente)
        public FrmCadastroCliente(int id, string nome, string cpf, string telefone, string email, string endereco)
        {
            InitializeComponent();

            clienteId = id;
            txtNome.Text = nome;
            txtCpf.Text = cpf;
            txtTel.Text = telefone;
            txtEmail.Text = email;
            txtEndereco.Text = endereco;

            txtCpf.Enabled = false; // CPF não pode ser alterado, é único
            btnCadastrar.Text = "Salvar Alterações"; // muda o texto do botão
        }

        // botão de salvar (serve para cadastrar e editar)
        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            string nome = txtNome.Text.Trim();
            string cpf = txtCpf.Text.Trim();
            string telefone = txtTel.Text.Trim();
            string email = txtEmail.Text.Trim();
            string endereco = txtEndereco.Text.Trim();

            // validações 
            if (string.IsNullOrEmpty(nome) || string.IsNullOrEmpty(cpf))
            {
                MessageBox.Show("Preencha ao menos Nome e CPF.");
                return;
            }

            if (!Regex.IsMatch(cpf, @"^\d{11}$"))
            {
                MessageBox.Show("CPF deve conter apenas números e ter exatamente 11 dígitos.");
                return;
            }

            if (!string.IsNullOrEmpty(telefone) && !Regex.IsMatch(telefone, @"^\d+$"))
            {
                MessageBox.Show("Telefone deve conter apenas números.");
                return;
            }

            if (!string.IsNullOrEmpty(email) &&
            !Regex.IsMatch(email, @"^[\w\.-]+@([\w-]+\.)+[\w-]{2,4}$"))
            {
                MessageBox.Show("Digite um e-mail válido (ex: nome@gmail.com).");
                return;
            }

            try
            {
                if (conexaoBD.Conectar())
                {
                    // se for cadastro (clienteId == null)
                    if (clienteId == null)
                    {
                        string verificaCpf = "SELECT COUNT(*) FROM clientes WHERE cpf = @cpf";
                        MySqlCommand cmdVerifica = new MySqlCommand(verificaCpf, conexaoBD.ObterConexao());
                        cmdVerifica.Parameters.AddWithValue("@cpf", cpf);
                        int existe = Convert.ToInt32(cmdVerifica.ExecuteScalar());

                        if (existe > 0)
                        {
                            MessageBox.Show("Já existe um cliente cadastrado com este CPF.");
                            return;
                        }

                        string sql = "INSERT INTO clientes (nome, cpf, telefone, email, endereco) " +
                                     "VALUES (@nome, @cpf, @telefone, @email, @endereco)";
                        MySqlCommand cmd = new MySqlCommand(sql, conexaoBD.ObterConexao());
                        cmd.Parameters.AddWithValue("@nome", nome);
                        cmd.Parameters.AddWithValue("@cpf", cpf);
                        cmd.Parameters.AddWithValue("@telefone", telefone);
                        cmd.Parameters.AddWithValue("@email", email);
                        cmd.Parameters.AddWithValue("@endereco", endereco);
                        cmd.ExecuteNonQuery();

                        MessageBox.Show(" Cliente cadastrado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LimparCampos();
                    }
                    else
                    {
                        // se for edição de dados
                        string sql = "UPDATE clientes SET nome=@nome, telefone=@telefone, email=@email, endereco=@endereco WHERE id=@id";
                        MySqlCommand cmd = new MySqlCommand(sql, conexaoBD.ObterConexao());
                        cmd.Parameters.AddWithValue("@nome", nome);
                        cmd.Parameters.AddWithValue("@telefone", telefone);
                        cmd.Parameters.AddWithValue("@email", email);
                        cmd.Parameters.AddWithValue("@endereco", endereco);
                        cmd.Parameters.AddWithValue("@id", clienteId);
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("✅ Cliente atualizado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close(); // fecha após salvar alterações
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar cliente: " + ex.Message);
            }
            finally
            {
                conexaoBD.Desconectar();
            }
        }

        private void btnVoltar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        // função para limpar campos 
        private void LimparCampos()
        {
            txtNome.Clear();
            txtCpf.Clear();
            txtTel.Clear();
            txtEmail.Clear();
            txtEndereco.Clear();
            txtNome.Focus();
        }
    }
}
