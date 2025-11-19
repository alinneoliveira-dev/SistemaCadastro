using System;
using System.Security.Cryptography;
using System.Text;

namespace CadastroLogin
{
    public static class Criptografia
    {
        public static string GerarHashSHA256(string texto)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(texto));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        public static bool VerificarHash(string senhaDigitada, string hashSalvo)
        {
            // gera o hash da senha que o usuário digitou
            string hashDaSenhaDigitada = GerarHashSHA256(senhaDigitada);

            // compara o hash gerado com o hash salvo no banco de dados
            return hashDaSenhaDigitada.Equals(hashSalvo, StringComparison.OrdinalIgnoreCase);
        }
    }
}