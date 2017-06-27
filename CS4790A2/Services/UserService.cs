using CS4790A3.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CS4790A3.Services
{
    public class UserService
    {



        public static String encryptPassword(String inputPassword)
        {
            Byte[] slt = Encoding.UTF8.GetBytes("badstaticsalt");
            Rfc2898DeriveBytes rfc2898DeriveBytes = new Rfc2898DeriveBytes(inputPassword, slt);
            rfc2898DeriveBytes.IterationCount = 10000;
            byte[] hash = rfc2898DeriveBytes.GetBytes(20);
            byte[] salt = rfc2898DeriveBytes.Salt;
            //Return the salt and the hash
            return Convert.ToBase64String(salt) + "|" + Convert.ToBase64String(hash);

        }

        internal static bool checkSecurityLevel(int? v1, int v2)
        {
            if (v1.HasValue)
                if (v1 == v2)
                    return true;
            return false;
        }
    }
}
