using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Security;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace StartAcademy8.BLogic
{
    public class EncryptionData
    {
        public string Sha256Encrypt(string input)
        {
            using var sha256 = SHA256.Create();
            byte[] bytes = Encoding.UTF8.GetBytes(input);
            byte[] hash = sha256.ComputeHash(bytes);
            return Convert.ToHexString(hash);
        }

        public string Sha512Encrypt(string input)
        {
            using var sha512 = SHA512.Create();
            byte[] bytes = Encoding.UTF8.GetBytes(input);
            byte[] hash = sha512.ComputeHash(bytes);
            return Convert.ToHexString(hash);
        }

        public void SaltEncrypt(string input)
        {
            byte[] byteSalt = new byte[16];
            string encryptedResult = string.Empty;
            string encryptedSalt = string.Empty;

            try
            {
                RandomNumberGenerator.Fill(byteSalt);
                encryptedResult = Convert.ToBase64String(
                    KeyDerivation.Pbkdf2(
                    password: input,
                    salt: byteSalt,
                    prf: KeyDerivationPrf.HMACSHA256,
                    iterationCount: 100000
                    ));
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
