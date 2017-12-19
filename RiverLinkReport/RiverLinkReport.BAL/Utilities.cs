using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiverLinkReport.BAL
{
    public static class Utilities
    {
        private static string Encrypt(string TextToEncrypt)
        {
            string EncryptedText = "";
            const string passPhrase = "myVoic3ismypassp0rt";  // can be any string
            const string saltValue = "s@1tyyyValues";         // can be any string
            const string hashAlgorithm = "SHA1";              // can be "MD5"
            const int passwordIterations = 2;                 // can be any number
            const string initVector = "@1B2c3wet5F6g7H8";     // must be 16 bytes
            const int keySize = 256;                          // can be 192 or 128
            EncryptedText = RijndaelSimple.Encrypt(TextToEncrypt, passPhrase, saltValue, hashAlgorithm, passwordIterations, initVector, keySize);
            return EncryptedText;
        }

        /// <summary>
        /// Decrypts the specified text to decrypt.
        /// </summary>
        /// <param name="TextToDecrypt">The text to decrypt.</param>
        /// <returns></returns>
        private static string Decrypt(string TextToDecrypt)
        {
            string DecryptedText = "";
            const string passPhrase = "myVoic3ismypassp0rt";  // can be any string
            const string saltValue = "s@1tyyyValues";         // can be any string
            const string hashAlgorithm = "SHA1";              // can be "MD5"
            const int passwordIterations = 2;                 // can be any number
            const string initVector = "@1B2c3wet5F6g7H8";     // must be 16 bytes
            const int keySize = 256;                          // can be 192 or 128
            DecryptedText = RijndaelSimple.Decrypt(TextToDecrypt, passPhrase, saltValue, hashAlgorithm, passwordIterations, initVector, keySize);
            return DecryptedText;
        }
    }
}
