using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace gLibrary.Models
{
    public class PasswordHash
    {
        private const int SaltSize = 8;
        private const int PBKDF2IterCount = 1000;
        private const int PBKDF2SubkeyLength = 128;

        public static string CreateHash(string password)
        {
            if (password == null)
            {
                return null;
            }
            else
            {
                byte[] salt;
                byte[] subkey;

                using (var deriveBytes = new Rfc2898DeriveBytes(password, SaltSize, PBKDF2IterCount))
                {
                    salt = deriveBytes.Salt;
                    subkey = deriveBytes.GetBytes(PBKDF2SubkeyLength);
                }

                byte[] outBytes = new byte[1 + SaltSize + PBKDF2SubkeyLength];
                Buffer.BlockCopy(salt, 0, outBytes, 1, SaltSize);
                Buffer.BlockCopy(subkey, 0, outBytes, 1 + SaltSize, PBKDF2SubkeyLength);

                return Convert.ToBase64String(outBytes);
            }
        }

        //hashedPassword format: salt + Hash(salt + password)
        public static bool VerifyHashedPassword(string hashedPassword, string password)
        {
            if (hashedPassword == null || password == null)
            {
                return false;
            }
            else
            {
                byte[] hashedPasswordBytes = Convert.FromBase64String(hashedPassword);

                if (hashedPasswordBytes.Length != (1 + SaltSize + PBKDF2SubkeyLength) || hashedPasswordBytes[0] != 0x00)
                {
                    return false;
                }

                byte[] salt = new byte[SaltSize];
                Buffer.BlockCopy(hashedPasswordBytes, 1, salt, 0, SaltSize);
                byte[] storedSubkey = new byte[PBKDF2SubkeyLength];
                Buffer.BlockCopy(hashedPasswordBytes, 1 + SaltSize, storedSubkey, 0, PBKDF2SubkeyLength);

                //generate subkey from string password
                byte[] generatedSubkey;
                using (var deriveBytes = new Rfc2898DeriveBytes(password, salt, PBKDF2IterCount))
                {
                    generatedSubkey = deriveBytes.GetBytes(PBKDF2SubkeyLength);
                }

                return storedSubkey.SequenceEqual(generatedSubkey);
            }
        }
    }
}
