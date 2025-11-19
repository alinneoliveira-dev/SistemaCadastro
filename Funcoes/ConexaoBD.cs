using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CadastroLogin
{
    public class ConexaoBD
    {
        //conexão com banco de dados mysql
        private string connectionString = "Server=localhost;Database=sistema_cadastro;Uid=root;Pwd=Alinne123;";
        private MySqlConnection conexao;

        public ConexaoBD()
        {
            conexao = new MySqlConnection(connectionString);
        }

        public MySqlConnection ObterConexao()
        {
            return conexao;
        }

        public bool Conectar()
        {
            try
            {
                if (conexao.State == ConnectionState.Closed)
                {
                    conexao.Open();
                }
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Erro ao conectar com o banco: {ex.Message}");
                return false;
            }
        }

        public void Desconectar()
        {
            if (conexao.State == ConnectionState.Open)
            {
                conexao.Close();
            }
        }
    }
}