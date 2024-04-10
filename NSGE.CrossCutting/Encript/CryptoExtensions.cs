using System.Security.Cryptography;

namespace NSGE.CrossCutting.Encript
{
    public static class CryptoExtensions
    {
        public static string Criptografar(this string toEncrypt)
        {
            if (string.IsNullOrEmpty(toEncrypt))
                throw new ArgumentException("O texto a ser criptografado não pode ser nulo ou vazio.");

            using (Aes aesAlg = Aes.Create())
            {
                byte[] key = aesAlg.Key;
                byte[] iv = aesAlg.IV;

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (ICryptoTransform encryptor = aesAlg.CreateEncryptor(key, iv))
                    {
                        using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                        {
                            using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                            {
                                swEncrypt.Write(toEncrypt);
                            }
                        }
                    }

                    byte[] encryptedBytes = msEncrypt.ToArray();
                    return Convert.ToBase64String(encryptedBytes);
                }
            }
        }
    }
}