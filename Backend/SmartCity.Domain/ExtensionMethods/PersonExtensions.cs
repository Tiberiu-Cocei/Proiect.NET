using System;
using System.Text;

namespace SmartCity.Domain.ExtensionMethods
{
    public static class PersonExtensions
    {
        public static string PasswordHashing(string password)
        {
            var bytes = new UTF8Encoding().GetBytes(password);
            byte[] hashBytes;
            using (var algorithm = new System.Security.Cryptography.SHA512Managed())
            {
                hashBytes = algorithm.ComputeHash(bytes);
            }
            return Convert.ToBase64String(hashBytes);
        }
    }
}