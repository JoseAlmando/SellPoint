using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SellPoint.Utils
{
    public static partial class ExtensionsMethods
    {
    
        public static string Encrypt(this string strCadena)
        {
            return EncriptarSHA512(EncriptarMD5(EncriptarSHA1(strCadena)));

        }

        public static string EncriptarMD5(this string strCadena)
        {
            using MD5 md5Hash = MD5.Create();
            return StringFromByteArray(md5Hash.ComputeHash(Encoding.UTF8.GetBytes(strCadena)));

        }

       
        public static string EncriptarSHA512(this string strCadena)
        {
            using var sha = SHA512.Create();
            return StringFromByteArray(sha.ComputeHash(Encoding.UTF8.GetBytes(strCadena)));

        }

        public static string EncriptarSHA256(this string strCadena)
        {
            using var sha = SHA256.Create();
            return StringFromByteArray(sha.ComputeHash(Encoding.UTF8.GetBytes(strCadena)));

        }

      
        public static string EncriptarSHA1(this string strCadena)
        {
            using var sha = SHA1.Create();
            return StringFromByteArray(sha.ComputeHash(Encoding.UTF8.GetBytes(strCadena)));

        }

        private static string StringFromByteArray(byte[] data)
        {
            StringBuilder sBuilder = new();

            foreach (byte @byte in data)
            {
                sBuilder.Append(@byte.ToString("x2"));
            }

            return sBuilder.ToString();
        }


    }
}
