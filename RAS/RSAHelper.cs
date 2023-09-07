using System.Security.Cryptography;

namespace RAS
{
    public class RSAHelper
    {
        public static RSAParameters RsaKeyInfo { get; set; }
        public System.Security.Cryptography.RSA Generate()
        {
            var rsa = System.Security.Cryptography.RSA.Create();
            RsaKeyInfo = rsa.ExportParameters(false);
            return rsa;
        }

        /// <summary>
        /// RSA加密
        /// </summary>
        /// <param name="DataToEncrypt"></param>
        /// <param name="RSAKeyInfo"></param>
        /// <param name="DoOAEPPadding"></param>
        /// <returns></returns>
        public static byte[] RSAEncrypt(byte[] DataToEncrypt, bool DoOAEPPadding)
        {
            try
            {
                byte[] encryptedData;
                using (var RSA = new RSACryptoServiceProvider())
                {
                    RSA.ImportParameters(RsaKeyInfo);
                    encryptedData = RSA.Encrypt(DataToEncrypt, DoOAEPPadding);
                }
                return encryptedData;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        /// <summary>
        /// RSA解密
        /// </summary>
        /// <param name="DataToDecrypt"></param>
        /// <param name="RSAKeyInfo"></param>
        /// <param name="DoOAEPPadding"></param>
        /// <returns></returns>
        public static byte[] RSADecrypt(byte[] DataToDecrypt, bool DoOAEPPadding)
        {
            try
            {
                byte[] decryptedData;
                //Create a new instance of RSACryptoServiceProvider.
                using (RSACryptoServiceProvider RSA = new())
                {
                    //Import the RSA Key information. This needs
                    //to include the private key information.
                    RSA.ImportParameters(RsaKeyInfo);

                    //Decrypt the passed byte array and specify OAEP padding.  
                    //OAEP padding is only available on Microsoft Windows XP or
                    //later.  
                    decryptedData = RSA.Decrypt(DataToDecrypt, DoOAEPPadding);
                }
                return decryptedData;
            }
            catch (CryptographicException e)
            {
                Console.WriteLine(e.ToString());

                return null;
            }
        }
    }
}