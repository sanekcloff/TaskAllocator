using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Data.Utilities.Encoders
{
    public static class PasswordEncoder
    {
        public static string Hash(ref string salt, string password)
        {
            byte[] randomSalt = new byte[8];
            using (var rnd = RandomNumberGenerator.Create())
            {
                rnd.GetBytes(randomSalt);
            }
            salt = randomSalt.ToString()!;
            using (var sha256 = SHA256.Create())
            {
                byte[] saltedPassword = Encoding.UTF8.GetBytes(password + salt);
                byte[] hashedpassword = sha256.ComputeHash(saltedPassword);
                return hashedpassword.ToString()!;
            }
        }
    }
}
