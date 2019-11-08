using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace NetCoreTodoApi.Common.Utilities
{
    public class HashUtility: IHashUtility
    {
        public string Encrypt(string text)
        {
            string salt = "4QtTb7jPc272uy8MmoWBkw";
            string hashed = Convert.ToBase64String(
                KeyDerivation.Pbkdf2(
                password: text,
                salt: Encoding.UTF8.GetBytes(salt),
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));
            return hashed;
        }
    }
}
