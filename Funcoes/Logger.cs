using MySql.Data.MySqlClient;
using System;

namespace CadastroLogin
{
    public static class Logger
    {
        //prática de devops - salva logs de erros no banco de dados
        public static void Registrar(string usuario, string acao, string mensagem)
        {
            try
            {
                ConexaoBD conexaoBD = new ConexaoBD();

                if (conexaoBD.Conectar())
                {
                    string sql = "INSERT INTO logs (data_hora, usuario, acao, mensagem) VALUES (@data, @usuario, @acao, @mensagem)";
                    MySqlCommand cmd = new MySqlCommand(sql, conexaoBD.ObterConexao());
                    cmd.Parameters.AddWithValue("@data", DateTime.Now);
                    cmd.Parameters.AddWithValue("@usuario", string.IsNullOrEmpty(usuario) ? "Sistema" : usuario);
                    cmd.Parameters.AddWithValue("@acao", acao);
                    cmd.Parameters.AddWithValue("@mensagem", mensagem);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                // se não conseguir logar no banco de dados, salva em arquivo local
                System.IO.File.AppendAllText("logs_falha.txt",
                    $"{DateTime.Now} - Erro ao registrar log: {ex.Message}\n");
            }
        }
    }
}
