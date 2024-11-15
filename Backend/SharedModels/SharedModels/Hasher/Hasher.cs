using System;
using System.Security.Cryptography;
using System.Text;

namespace SharedModels.Hasher
{
    public class Hasher
    {
        public static string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
                byte[] hashBytes = sha256.ComputeHash(passwordBytes);
                StringBuilder sb = new StringBuilder();

                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("x2"));
                }
                //Return only the first 50 characters of the hash because of database limitations on visitor account password length
                return sb.ToString().Substring(0, 50);
            }
        }
    }
}
