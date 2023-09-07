using AES;
using RAS;
using RSA;
using System.Security.Cryptography;
using System.Text;

namespace EncryptAndDecrypt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StoreKey.Demo();
            //AES();
            //return;
            //RSA()
        }

        static void AES()
        {
            string original = "Here is some data to encrypt!";

            // Create a new instance of the Aes
            // class.  This generates a new key and initialization
            // vector (IV).
            using Aes myAes = Aes.Create();

            UnicodeEncoding ByteConverter = new();
            var k = ByteConverter.GetString(myAes.Key);
            var v = ByteConverter.GetString(myAes.IV);
            // Encrypt the string to an array of bytes.
            byte[] encrypted = AESHelper.EncryptStringToBytes_Aes(original);

            // Decrypt the bytes to a string.
            string roundtrip = AESHelper.DecryptStringFromBytes_Aes(encrypted);

            //Display the original data and the decrypted data.
            Console.WriteLine("Original:   {0}", original);
            Console.WriteLine("Round Trip: {0}", roundtrip);
        }

        static void RSA()
        {
            try
            {
                UnicodeEncoding ByteConverter = new();
                byte[] dataToEncrypt = ByteConverter.GetBytes("Data to Encrypt");
                byte[]? encryptedData;
                byte[]? decryptedData;

                //Create a new instance of RSACryptoServiceProvider to generate
                //public and private key data.
                using RSACryptoServiceProvider RSA = new();

                var privatekey = RSA.ToXmlString(true);
                var publickey = RSA.ToXmlString(false);//公钥

                //Pass the data to ENCRYPT, the public key information 
                //(using RSACryptoServiceProvider.ExportParameters(false),
                //and a boolean flag specifying no OAEP padding.
                encryptedData = RSAHelper.RSAEncrypt(dataToEncrypt,  false);

                //Pass the data to DECRYPT, the private key information 
                //(using RSACryptoServiceProvider.ExportParameters(true),
                //and a boolean flag specifying no OAEP padding.
                decryptedData = RSAHelper.RSADecrypt(encryptedData, false);

                //Display the decrypted plaintext to the console. 
                Console.WriteLine("Decrypted plaintext: {0}", ByteConverter.GetString(decryptedData));
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}