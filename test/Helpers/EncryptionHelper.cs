using System.Security.Cryptography;
using System.Text;

namespace test.Helpers
{
    public class EncryptionHelper
    {
        private static readonly byte[] Key = new byte[16]; // 16 bytes for AES-128 key
        private static readonly byte[] IV = new byte[16]; // 16 bytes for AES IV

        public static string EncryptString(string plainText)
        {
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;

                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                byte[] encryptedBytes;

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        byte[] plainBytes = Encoding.UTF8.GetBytes(plainText);
                        csEncrypt.Write(plainBytes, 0, plainBytes.Length);
                    }
                    encryptedBytes = msEncrypt.ToArray();
                }

                return Convert.ToBase64String(encryptedBytes);
            }
        }

        public static string DecryptString(string cipherText)
        {
            try
            {
                byte[] cipherBytes = Convert.FromBase64String(cipherText);

                using (Aes aesAlg = Aes.Create())
                {
                    aesAlg.Key = Key;
                    aesAlg.IV = IV;

                    ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                    using (MemoryStream msDecrypt = new MemoryStream(cipherBytes))
                    {
                        using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                        {
                            using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                            {
                                return srDecrypt.ReadToEnd();
                            }
                        }
                    }
                }
            }
            catch (FormatException ex)
            {
                // Handle invalid Base64 string
                Console.WriteLine($"Error decrypting string: {ex.Message}");
                return null; // Or throw an exception or handle the error appropriately
            }
            catch (CryptographicException ex)
            {
                // Handle cryptographic errors
                Console.WriteLine($"Error decrypting string: {ex.Message}");
                return null; // Or throw an exception or handle the error appropriately
            }
        }
    }
}
