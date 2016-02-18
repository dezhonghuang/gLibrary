using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace gLibrary.Models
{
    public static class Encryption
    {
        public static string Encrypt(string stringToEncrypt, string sEncryptionKey)
        {
            TripleDES des = CreateDes(sEncryptionKey);
            ICryptoTransform ct = des.CreateEncryptor();
            byte[] input = Encoding.Unicode.GetBytes(stringToEncrypt);
            des.Clear();

            return Convert.ToBase64String(ct.TransformFinalBlock(input, 0, input.Length));
        }

        public static string Decrypt(string stringToDecrypt, string sEncryptionKey)
        {
            int m = stringToDecrypt.Length % 4;
            TripleDES des = CreateDes(sEncryptionKey);
            ICryptoTransform ct = des.CreateDecryptor();
            stringToDecrypt = stringToDecrypt.Replace(' ', '+');
            byte[] input = Convert.FromBase64String(stringToDecrypt);
            des.Clear();
            return Encoding.Unicode.GetString(ct.TransformFinalBlock(input, 0, input.Length));
        }

        static TripleDES CreateDes(string key)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider();
            des.Key = md5.ComputeHash(UnicodeEncoding.Unicode.GetBytes(key));
            des.IV = new byte[des.BlockSize / 8];

            return des;
        }
    }
}
