using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hovlibrary
{
    public static class Encrypt
    {
        public static string Hash(string data)
        {
            return Hash(Encoding.UTF8.GetBytes(data));
        }

        public static string Hash(byte[] data)
        {
            var hash = System.Security.Cryptography.SHA256.Create();
            byte[] hData = hash.ComputeHash(data);
            return ToHex(data);
        }

        public static string ToHex(byte[] bytes)
        {
            StringBuilder result = new StringBuilder(bytes.Length * 2);

            for (int i = 0; i < bytes.Length; i++)
            {
                result.Append(bytes[i].ToString("x2"));
            }

            return result.ToString();
        }

    }
}
