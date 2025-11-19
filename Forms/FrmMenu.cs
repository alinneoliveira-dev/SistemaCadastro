using CadastroC_;
using CadastroLogin;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace CadastroLogin
{
    public partial class FrmMenu : Form
    {
        private ConexaoBD conexaoBD = new ConexaoBD();

        public FrmMenu()
        {
            InitializeComponent();
            CarregarClientes();
            AplicarTema();
            CarregarClientes();
        }

        //  lista de clientes no DataGridView
        private void CarregarClientes()
        {
            try
            {
                if (conexaoBD.Conectar())
                {
                    string sql = "SELECT id, nome, cpf, telefone, endereco, email FROM clientes";
                    MySqlDataAdapter da = new MySqlDataAdapter(sql, conexaoBD.ObterConexao());
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvLista.DataSource = dt;
                }
                dgvLista.RowHeadersVisible = false;

                // Ajusta os títulos das colunas 
                dgvLista.Columns["id"].HeaderText = "ID";
                dgvLista.Columns["nome"].HeaderText = "Nome";
                dgvLista.Columns["cpf"].HeaderText = "CPF";
                dgvLista.Columns["telefone"].HeaderText = "Telefone";
                dgvLista.Columns["endereco"].HeaderText = "Endereço";
                dgvLista.Columns["email"].HeaderText = "E-mail";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar clientes: " + ex.Message);
            }
            finally
            {
                conexaoBD.Desconectar();
            }
        }

        private void btnCriar_Click_1(object sender, EventArgs e)
        {
            {
                FrmCadastroCliente frm = new FrmCadastroCliente();
                frm.ShowDialog();
                CarregarClientes(); // atualiza após cadastrar
            }
        }


        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvLista.Rows.Count == 0)
            {
                MessageBox.Show("Não há clientes cadastrados.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (dgvLista.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione um cliente para editar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // captura os dados da linha selecionada
            int id = Convert.ToInt32(dgvLista.SelectedRows[0].Cells["id"].Value);
            string nome = dgvLista.SelectedRows[0].Cells["nome"].Value.ToString();
            string cpf = dgvLista.SelectedRows[0].Cells["cpf"].Value.ToString();
            string telefone = dgvLista.SelectedRows[0].Cells["telefone"].Value.ToString();
            string email = dgvLista.SelectedRows[0].Cells["email"].Value.ToString();
            string endereco = dgvLista.SelectedRows[0].Cells["endereco"].Value.ToString();

            // abre o formulário de edição com os dados
            FrmCadastroCliente frm = new FrmCadastroCliente(id, nome, cpf, telefone, email, endereco);
            frm.ShowDialog();

            // atualiza a lista após editar
            CarregarClientes();
        }

        private void btnExcluir_Click_1(object sender, EventArgs e)

        {
            // verifica se há alguma linha selecionada
            if (dgvLista.Rows.Count == 0)
            {
                MessageBox.Show("Não há clientes cadastrados.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (dgvLista.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione um cliente para excluir.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // obtém o nome e o ID do cliente selecionado
            string nome = dgvLista.SelectedRows[0].Cells["nome"].Value.ToString();
            int id = Convert.ToInt32(dgvLista.SelectedRows[0].Cells["id"].Value);

            // exibe a mensagem de confirmação
            DialogResult confirm = MessageBox.Show(
                $"Tem certeza que deseja excluir o cliente '{nome}'?",
                "Confirmar exclusão",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            // se o usuário clicar em "Não", apenas retorna ao menu
            if (confirm == DialogResult.No)
            {
                MessageBox.Show("Ação cancelada.", "Cancelado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // se o usuário confirmar, exclui do banco de dados
            try
            {
                if (conexaoBD.Conectar())
                {
                    string sql = "DELETE FROM clientes WHERE id = @id";
                    MySqlCommand cmd = new MySqlCommand(sql, conexaoBD.ObterConexao());
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show($"Cliente '{nome}' excluído com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Logger.Registrar("Admin", "Exclusão de cliente", $"Cliente ID {id} excluído.");
                // prática de DevOps para registrar Logs de erro no banco de dados


                CarregarClientes();
            }
            catch (Exception ex)
            {
                
                MessageBox.Show("Erro ao excluir o cliente: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conexaoBD.Desconectar();
            }
        }

        private void AplicarTema()
        {
            Color primario = Color.FromArgb(196, 115, 208);       
            Color primarioEscuro = Color.FromArgb(156, 82, 165);  
            Color primarioClaro = Color.FromArgb(222, 163, 228);  
            Color fundoSuave = Color.FromArgb(245, 229, 247);     

            this.BackColor = fundoSuave;

            foreach (Control c in this.Controls)
            {
                if (c is Button btn)
                {
                    btn.BackColor = primario;
                    btn.ForeColor = Color.White;
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderSize = 0;
                    btn.Font = new Font("Segoe UI", 11, FontStyle.Bold);

                    // Hover
                    btn.MouseEnter += (s, e) => btn.BackColor = primarioEscuro;
                    btn.MouseLeave += (s, e) => btn.BackColor = primario;

                }
            }

            EstilizarGrid();
        }

        private void EstilizarGrid()
        {
            Color primario = Color.FromArgb(196, 115, 208);       
            Color primarioEscuro = Color.FromArgb(156, 82, 165);  
            Color primarioClaro = Color.FromArgb(222, 163, 228);  

            dgvLista.BackgroundColor = Color.White;
            dgvLista.BorderStyle = BorderStyle.None;
            dgvLista.EnableHeadersVisualStyles = false;

            dgvLista.ColumnHeadersDefaultCellStyle.BackColor = primario;
            dgvLista.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvLista.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            dgvLista.DefaultCellStyle.SelectionBackColor = primarioEscuro;
            dgvLista.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvLista.DefaultCellStyle.Font = new Font("Segoe UI", 10);

            dgvLista.GridColor = primarioClaro;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmEsqueciSenha frmEsqueci = new FrmEsqueciSenha();
            frmEsqueci.ShowDialog();
        }
    }
    }
    

