using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Services.Tools
{
    public class Encrypt
    {
        public static string EncriptPassword(string pass)
        {
            try
            {
                SHA1 sha1 = new SHA1CryptoServiceProvider();
                byte[] inputBytes = (new UnicodeEncoding()).GetBytes(pass);
                byte[] hash = sha1.ComputeHash(inputBytes);

                return Convert.ToBase64String(hash);
            }
            catch (Exception ex)
            {
                return "";
            }

        }
    }
}
