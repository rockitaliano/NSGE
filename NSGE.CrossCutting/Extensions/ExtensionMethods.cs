using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace NSGE.CrossCutting.Extensions
{
    public static class ExtensionMethods
    {
        // Substitua a chave abaixo por uma chave aleatória e segura em um ambiente de produção
        private static readonly byte[] Key = Encoding.UTF8.GetBytes("ChaveDeCriptografia123");

        public static DateTime BrasilDate(this DateTime date)
        {
            return date.Date;
        }

        public static bool CompararPassword(this string crypto, string password)
        {
            if (string.IsNullOrEmpty(crypto) || string.IsNullOrEmpty(password))
                return false;

            byte[] cryptoBytes = Convert.FromBase64String(crypto);

            using (var sha256 = SHA256.Create())
            {
                byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
                byte[] hashBytes = sha256.ComputeHash(passwordBytes);

                return StructuralComparisons.StructuralEqualityComparer.Equals(cryptoBytes, hashBytes);
            }
        }

        public static string Criptografar(this string toEncrypt)
        {
            if (string.IsNullOrEmpty(toEncrypt))
                throw new ArgumentNullException(nameof(toEncrypt));

            string chave = "SuaChaveDeCriptografia"; // Substitua pela sua chave de criptografia secreta
            byte[] chaveBytes = Encoding.UTF8.GetBytes(chave);

            using (Aes aes = Aes.Create())
            {
                aes.Key = chaveBytes;
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;

                byte[] textoBytes = Encoding.UTF8.GetBytes(toEncrypt);

                // IV (Initialization Vector) - O vetor de inicialização deve ser único e imprevisível
                // Você pode gerar um novo IV a cada vez ou armazená-lo junto com a criptografia
                byte[] iv = new byte[aes.BlockSize / 8];
                RandomNumberGenerator.Fill(iv);

                aes.IV = iv;

                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(textoBytes, 0, textoBytes.Length);
                    }

                    byte[] criptografadoBytes = iv.Concat(ms.ToArray()).ToArray();
                    return Convert.ToBase64String(criptografadoBytes);
                }
            }
        }

        public static DateTime DateForZoneId(this DateTime date, string zoneId)
        {
            if (string.IsNullOrEmpty(zoneId))
                throw new ArgumentException("O ID do fuso horário não pode ser nulo ou vazio.", nameof(zoneId));

            TimeZoneInfo timeZone = TimeZoneInfo.FindSystemTimeZoneById(zoneId);
            DateTime convertedDate = TimeZoneInfo.ConvertTime(date, timeZone);

            return convertedDate;
        }

        public static string Descriptografar(this string cipherString)
        {
            if (string.IsNullOrEmpty(cipherString))
                return string.Empty;

            byte[] cipherBytes = Convert.FromBase64String(cipherString);

            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = GetValidKey(Key, aesAlg);
                aesAlg.IV = new byte[aesAlg.BlockSize / 8];
                aesAlg.Padding = PaddingMode.PKCS7;

                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                using (var msDecrypt = new System.IO.MemoryStream(cipherBytes))
                using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                using (var memoryStream = new MemoryStream())
                {
                    
                    byte[] decryptedBytes = memoryStream.ToArray();
                    return Encoding.UTF8.GetString(decryptedBytes);
                    // Verificar se o tamanho do texto cifrado é um múltiplo do tamanho do bloco
                    //if (cipherBytes.Length % aesAlg.BlockSize != 0)
                    //    throw new ArgumentException("O texto cifrado não é um bloco completo.");

                    //return srDecrypt.ReadToEnd();
                }
            }
        }

        public static DateTime FirstDay(this DateTime date)
        {
            return new DateTime(date.Year, date.Month, 1, 0, 0, 0, date.Kind);
        }

        public static DateTime FirstHour(this DateTime date)
        {
            return new DateTime(date.Year, date.Month, date.Day, 0, 0, 0, date.Kind);
        }

        public static IHtmlContent ForceSelected(this IHtmlContent? helper, string? selected)
        {
            if (helper is TagBuilder tagBuilder && tagBuilder.TagName == "option")
            {
                if (tagBuilder.Attributes.ContainsKey("value") && tagBuilder.Attributes["value"] == selected)
                {
                    tagBuilder.Attributes["selected"] = "selected";
                }
            }
            return helper;
        }

        public static DateTime FusoHorario(this DateTime date, int fuso, bool horarioDeVerao = false)
        {
            TimeSpan timeSpan = TimeSpan.FromHours(fuso);
            if (horarioDeVerao && TimeZoneInfo.Local.IsDaylightSavingTime(date))
            {
                timeSpan = timeSpan.Add(TimeSpan.FromHours(1));
            }

            return date.Add(timeSpan);
        }

        public static DateTime LastDay(this DateTime date)
        {
            int daysInMonth = DateTime.DaysInMonth(date.Year, date.Month);
            return new DateTime(date.Year, date.Month, daysInMonth, 23, 59, 59, date.Kind);
        }

        public static DateTime LastHour(this DateTime date)
        {
            return new DateTime(date.Year, date.Month, date.Day, 23, 59, 59, date.Kind);
        }

        private static byte[] GetValidKey(byte[] key, Aes aesAlg)
        {
            byte[] validKey = new byte[aesAlg.KeySize / 8];
            Array.Copy(key, validKey, Math.Min(key.Length, validKey.Length));
            return validKey;
        }
    }
}