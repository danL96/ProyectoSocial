using System;
using System.IO;
using System.Text;
using System.Security.Cryptography;

namespace ProyectoSocial.LogicadeNegocio
{
    public class ProyectoSocialEncrypter
    {

        private const string Key = "jkui73rmH5nwDpBz";

        public string EncryptString(string text)
        {
            var plainTextByes = Encoding.UTF8.GetBytes(text);

            using (var ms = new MemoryStream())
            {
                using (var des = CreateTripleDes())
                {
                    using (var cryptoStream = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cryptoStream.Write(plainTextByes, 0, plainTextByes.Length);
                        cryptoStream.FlushFinalBlock();
                    }
                }

                return Convert.ToBase64String(ms.ToArray());
            }

        }

        public string DecryptString(string text)
        {
            try
            {
                var encryptedTextBytes = Convert.FromBase64String(text);

                using (var ms = new MemoryStream())
                {
                    using (var des = CreateTripleDes())
                    {
                        using (var cryptoStream = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write))
                        {
                            cryptoStream.Write(encryptedTextBytes, 0, encryptedTextBytes.Length);
                            cryptoStream.FlushFinalBlock();
                        }
                    }

                    return Encoding.UTF8.GetString(ms.ToArray());
                }
            }
            catch (Exception ex)
            {
                throw new ProyectoSocialException("Cifrado inválido", ex);
            }
            
        }

        private static TripleDES CreateTripleDes()
        {
            var des = new TripleDESCryptoServiceProvider();
            des.IV = new byte[des.BlockSize/8];
            var md5 = new MD5CryptoServiceProvider();
            des.Key = md5.ComputeHash(Encoding.UTF8.GetBytes(Key));
            return des;
        }
    }

}
