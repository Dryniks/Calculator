using System;
using System.IO;
using System.Text;
using System.Security.Cryptography;

namespace Data
{
    /// <summary> Утилита шифрования </summary>
    public static class EncryptionUtility
    {
        public static string EncryptAES(this string dataString, string passPhrase)
        {
            using var aes = Aes.Create();

            passPhrase = passPhrase.Substring(0, 16);
            aes.Key = Encoding.ASCII.GetBytes(passPhrase);
            aes.IV = new byte[]
            {
                0x01, 0x03, 0x05, 0x07, 0x09, 0x0A, 0x0C, 0x0E, 0x01, 0x03, 0x05, 0x07, 0x09, 0x0A, 0x0C, 0x0E
            };

            var encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

            using var memoryStream = new MemoryStream();
            using var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write);
            using var streamWriter = new StreamWriter(cryptoStream);

            streamWriter.Write(dataString);
            return Convert.ToBase64String(memoryStream.ToArray());
        }

        public static string DecryptAES(this string sourceString, string passPhrase)
        {
            using var aes = Aes.Create();

            passPhrase = passPhrase.Substring(0, 16);
            aes.Key = Encoding.ASCII.GetBytes(passPhrase);
            aes.IV = new byte[]
            {
                0x01, 0x03, 0x05, 0x07, 0x09, 0x0A, 0x0C, 0x0E, 0x01, 0x03, 0x05, 0x07, 0x09, 0x0A, 0x0C, 0x0E
            };

            var buffer = Convert.FromBase64String(sourceString);

            var decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

            using var memoryStream = new MemoryStream(buffer);
            using var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
            using var streamReader = new StreamReader(cryptoStream);

            return streamReader.ReadToEnd();
        }
    }
}