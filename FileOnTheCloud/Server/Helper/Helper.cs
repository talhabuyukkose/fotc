using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace FileOnTheCloud.Server.Helper
{
    public class Helper
    {
        public static string GetConnectionString()
        {
            return @"Host=localhost;Port=5432;Database=akarecenter;User Id=postgres;Password=t825420;";
        }

        public static string Createhmacsha256(string message)
        {
            string secret = "honeysoft";
            var encoding = new System.Text.ASCIIEncoding();
            byte[] keyByte = encoding.GetBytes(secret);
            byte[] messageBytes = encoding.GetBytes(message);
            using (var hmacsha256 = new HMACSHA256(keyByte))
            {
                byte[] hashmessage = hmacsha256.ComputeHash(messageBytes);
                return Convert.ToBase64String(hashmessage);
            }
        }
    }
}
