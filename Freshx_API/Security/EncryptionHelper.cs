using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Freshx_API.Helpers
{
    public static class EncryptionHelper
    {

        public static byte[] GenerateKey(string password, byte[] salt)
        {
            using (var rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, salt, 100000, HashAlgorithmName.SHA256))
            {
                return rfc2898DeriveBytes.GetBytes(32);
            }
        }

        public static string Decrypt(string cipherText, byte[] key)
        {
            try
            {
                cipherText = cipherText.Replace("\\u002B", "+").Replace("\\u003D", "=");
                var fullCipher = Convert.FromBase64String(cipherText);
                var iv = new byte[16];
                var cipher = new byte[fullCipher.Length - iv.Length];

                Buffer.BlockCopy(fullCipher, 0, iv, 0, iv.Length);
                Buffer.BlockCopy(fullCipher, iv.Length, cipher, 0, cipher.Length);

                using (var aes = Aes.Create())
                {
                    aes.Key = key;
                    aes.IV = iv;

                    using (var decryptor = aes.CreateDecryptor(aes.Key, aes.IV))
                    using (var ms = new MemoryStream(cipher))
                    using (var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                    using (var reader = new StreamReader(cs))
                    {
                        return reader.ReadToEnd();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi giải mã: {ex.Message}");
                return cipherText; // Trả về chuỗi gốc nếu không thể giải mã
            }
        }
    }
}
