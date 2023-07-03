namespace Data
{
    /// <summary>
    /// Шифроватор
    /// </summary>
    public class Encryptor
    {
        private const string Key = "sda";

        /// <summary>
        /// Зашифровать строку
        /// </summary>
        /// <param name="source">Шифруемая строка</param>
        /// <returns>Результат шифрования</returns>
        public string Encrypt(string source)
        {
// #if !UNITY_EDITOR
//             return source.EncryptAES(Key);
// #else
            return source;
// #endif
        }

        /// <summary>
        /// Расшифровать строку
        /// </summary>
        /// <param name="source">Шифровання строка</param>
        /// <returns>Результат расшифровки</returns>
        public string Decrypt(string source)
        {
// #if !UNITY_EDITOR
//             return source.DecryptAES(Key);
// #else
            return source;
// #endif
        }
    }
}