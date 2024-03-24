using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace VIZ_N3
{
    internal class viz3
    {
        public static byte[] EncryptAes(byte[] data, out byte[] key, out byte[] iv, int keySize)
        {
            using (var aes = Aes.Create())
            {
                aes.KeySize = keySize;
                iv = aes.IV;
                aes.GenerateKey();
                key = aes.Key;
                foreach (byte b in key)
                {
                    Console.WriteLine(b);
                }

                aes.Padding = PaddingMode.PKCS7; 
                aes.Mode = CipherMode.CBC;

                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        csEncrypt.Write(data, 0, data.Length);
                        csEncrypt.FlushFinalBlock();
                    }
                    return msEncrypt.ToArray();
                }
            }
        }
        public static byte[] DecryptAes(byte[] encryptedData, byte[] key, byte[] iv, int keySize)
        {
            using (var aes = Aes.Create())
            {
                aes.KeySize = keySize;
                aes.IV = iv;
                aes.Key = key;

                aes.Padding = PaddingMode.PKCS7;
                aes.Mode = CipherMode.CBC;
                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                using (MemoryStream msDecrypt = new MemoryStream(encryptedData))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (MemoryStream msPlainText = new MemoryStream())
                        {
                            csDecrypt.CopyTo(msPlainText);
                            return msPlainText.ToArray();
                        }
                    }
                }
            }
        }
        public static string FileTypeFromPath(string filePath)
        {
            int extentionIndex = filePath.LastIndexOf('.');
            if (extentionIndex != -1)
            {
                string result = filePath.Substring(extentionIndex);
                return result;
            }
            else
            {
                return ".idk";
            }
        }
        public static byte[] EncryptRSA(byte[] data, string publicKey, int keySize)
        {
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                rsa.KeySize = keySize;
                rsa.FromXmlString(publicKey);
                return rsa.Encrypt(data, false);
            }
        }
        public static byte[] DecryptRSA(byte[] data, string privateKey, int keySize)
        {
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                rsa.KeySize = keySize;
                rsa.FromXmlString(privateKey);
                return rsa.Decrypt(data, false);
            }
        }
        public static void RSAGetKeys(out string publickey , out string privatekey, int keySize)
        {
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(keySize))
            {
                publickey = rsa.ToXmlString(false);
                privatekey = rsa.ToXmlString(true);
            } 
        }
    }
}
