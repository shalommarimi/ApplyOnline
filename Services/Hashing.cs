using System.Security.Cryptography;
using System.Text;

namespace ApplyOnline.Services
{
    public class Hashing
    {

        public string HashPassword(string input)
        {

            byte[] hash;
            using (var sha1CryptoServiceProvider = new SHA1CryptoServiceProvider())
            {
                hash = sha1CryptoServiceProvider.ComputeHash(Encoding.Unicode.GetBytes(input + "SHA1"));
            }
            var stringBuilder = new StringBuilder();

            foreach (byte b in hash) stringBuilder.AppendFormat("{0:x2}", b);
            {
                return stringBuilder.ToString();
            }
        }
    }
}