using System;
using System.IO;
using System.Security.Cryptography;

/* *****************************************************************************
 * File:    CryptoExtensions.cs
 * Author:  Philip Pierce - Wednesday, September 24, 2014
 * Description:
 *  Extensions for cryptography
 *  
 * History:
 *  Wednesday, September 24, 2014 - Created
 * ****************************************************************************/

/// <summary>
/// Extensions for cryptography
/// </summary>
public static class CryptoExtensions
{
    #region RandomNumber

    /// <summary>
    /// Generator for the random number generator
    /// </summary>
    private static readonly RNGCryptoServiceProvider RandomGenerator = new RNGCryptoServiceProvider();

    // http://scottlilly.com/create-better-random-numbers-in-c/

    /// <summary>
    /// Returns a random number within the range, inclusive
    /// </summary>
    /// <param name="minimumValue">min number</param>
    /// <param name="maximumValue">max number, inclusive</param>
    public static int RandomRangeInclusive(this int minimumValue, int maximumValue)
    {
        byte[] randomNumber = new byte[1];
        RandomGenerator.GetBytes(randomNumber);

        // We are using Math.Max, and subtracting 0.00000000001, 
        // to ensure "multiplier" will always be between 0.0 and .99999999999
        // Otherwise, it's possible for it to be "1", which causes problems in our rounding.
        //double multiplier = Math.Max(0, (randomNumber[0].ToDouble() / 255d) - 0.00000000001d);

        //// We need to add one to the range, to allow for the rounding done with Math.Floor
        //int range = maximumValue - minimumValue + 1;
        //double randomValueInRange = Math.Floor(multiplier * range);

        // We need to add one to the range, to allow for the rounding done with Math.Floor
        return (int)(
            minimumValue +
            Math.Floor( // randomValueInRange
                (Math.Max(0, (randomNumber[0].ToDouble() / 255d) - 0.00000000001d)) *  // multiplier
                (maximumValue - minimumValue + 1))); // range
    }

    // RandomNumber
    #endregion

    #region Variables

    // http://www.random.org/bytes/
    // 1024 bytes

    /// <summary>
    /// Default public key
    /// </summary>
    private static readonly byte[] DefaultPublicKey = new byte[] { 15, 121, 93, 113, 94, 87, 126, 221, 174, 43, 119, 38, 223, 121, 101, 188, 189, 196, 231, 60, 120, 72, 151, 78, 213, 238, 113, 103, 26, 97, 234, 57, 246, 125, 59, 26, 247, 196, 251, 100, 113, 156, 193, 122, 84, 216, 49, 61, 184, 23, 92, 38, 72, 224, 68, 210, 13, 214, 235, 78, 135, 185, 166, 237, 166, 46, 224, 63, 152, 76, 174, 32, 168, 227, 31, 29, 48, 121, 249, 254, 250, 216, 41, 171, 162, 55, 97, 187, 197, 126, 119, 51, 62, 20, 214, 179, 219, 81, 218, 97, 36, 126, 113, 71, 111, 190, 207, 174, 96, 198, 125, 182, 51, 221, 222, 153, 199, 162, 81, 191, 150, 63, 202, 221, 57, 171, 195, 247, 146, 248, 66, 203, 18, 173, 235, 28, 99, 252, 215, 215, 112, 113, 163, 249, 134, 74, 226, 157, 12, 117, 212, 61, 115, 38, 36, 182, 88, 152, 183, 57, 175, 203, 245, 155, 91, 74, 133, 190, 41, 156, 154, 50, 6, 197, 110, 30, 36, 12, 123, 200, 123, 134, 20, 168, 66, 244, 104, 243, 65, 201, 170, 94, 182, 198, 54, 167, 136, 76, 235, 186, 115, 233, 200, 18, 221, 9, 244, 248, 242, 217, 153, 76, 20, 253, 37, 208, 144, 154, 203, 40, 188, 47, 2, 169, 249, 50, 121, 241, 139, 216, 92, 114, 180, 123, 204, 25, 231, 186, 202, 42, 194, 46, 27, 61, 74, 238, 66, 150, 208, 138, 149, 4, 41, 143, 126, 145, 90, 62, 19, 100, 220, 229, 142, 137, 173, 86, 229, 196, 195, 197, 70, 72, 168, 197, 230, 25, 177, 11, 18, 50, 166, 84, 219, 167, 144, 104, 103, 124, 37, 149, 52, 109, 59, 199, 122, 180, 252, 218, 17, 187, 167, 166, 107, 251, 94, 60, 171, 148, 206, 245, 158, 83, 65, 76, 122, 88, 50, 8, 178, 156, 6, 179, 178, 228, 211, 9, 206, 190, 4, 163, 210, 117, 199, 193, 5, 7, 164, 199, 8, 195, 36, 160, 199, 215, 232, 67, 155, 195, 235, 165, 59, 36, 50, 245, 162, 114, 66, 86, 115, 26, 71, 241, 62, 118, 84, 134, 111, 68, 111, 48, 136, 143, 5, 9, 234, 157, 115, 247, 9, 118, 31, 17, 104, 70, 147, 46, 3, 252, 100, 215, 108, 240, 104, 56, 195, 81, 20, 239, 140, 58, 48, 84, 243, 212, 5, 234, 243, 156, 127, 151, 56, 42, 190, 20, 160, 26, 44, 251, 47, 60, 184, 54, 186, 25, 167, 155, 101, 106, 27, 81, 99, 250, 43, 169, 228, 42, 134, 51, 62, 35, 99, 103, 240, 50, 44, 76, 167, 60, 49, 28, 33, 80, 126, 85, 1, 152, 119, 174, 158, 68, 128, 30, 62, 63, 149, 164, 125, 230, 127, 197, 135, 168, 121, 254, 165, 252, 9, 221, 207, 206, 41, 8, 207, 148, 231, 136, 141, 253, 252, 206, 168, 205, 142, 81, 176, 118, 141, 33, 239, 244, 73, 38, 238, 251, 14, 211, 185, 144, 201, 95, 51, 168, 219, 52, 208, 32, 189, 254, 150, 93, 68, 97, 53, 93, 153, 131, 133, 152, 236, 75, 94, 102, 17, 189, 226, 31, 254, 7, 116, 61, 204, 5, 220, 246, 152, 155, 132, 226, 60, 150, 150, 128, 170, 188, 80, 139, 73, 121, 227, 6, 145, 15, 64, 121, 53, 236, 69, 188, 242, 212, 176, 75, 42, 135, 183, 94, 83, 77, 174, 219, 84, 223, 243, 35, 65, 101, 57, 170, 240, 39, 92, 64, 79, 129, 4, 111, 164, 46, 180, 216, 114, 110, 212, 48, 206, 99, 79, 73, 157, 176, 180, 239, 183, 30, 239, 240, 39, 168, 235, 86, 186, 71, 163, 65, 96, 142, 93, 55, 175, 94, 10, 143, 20, 190, 200, 206, 26, 140, 58, 251, 148, 112, 65, 144, 232, 40, 55, 32, 240, 29, 58, 182, 164, 53, 90, 173, 170, 208, 248, 21, 13, 186, 116, 253, 128, 234, 76, 95, 160, 244, 58, 246, 52, 173, 34, 190, 195, 142, 45, 156, 104, 233, 238, 72, 140, 87, 168, 1, 230, 29, 153, 141, 117, 208, 230, 150, 61, 176, 162, 231, 223, 239, 206, 115, 5, 76, 212, 253, 243, 226, 229, 59, 234, 49, 206, 20, 160, 175, 136, 129, 39, 198, 222, 17, 146, 7, 40, 150, 176, 12, 247, 24, 208, 30, 184, 17, 109, 164, 82, 165, 22, 123, 74, 46, 221, 179, 172, 159, 144, 113, 223, 165, 22, 120, 180, 181, 248, 79, 136, 241, 181, 140, 235, 19, 5, 10, 131, 39, 247, 137, 198, 174, 30, 11, 92, 2, 81, 93, 128, 136, 144, 98, 126, 158, 120, 125, 221, 39, 250, 53, 139, 188, 227, 242, 221, 111, 1, 65, 180, 221, 105, 64, 102, 245, 208, 100, 166, 154, 38, 199, 30, 209, 40, 102, 104, 137, 250, 234, 44, 105, 8, 98, 83, 140, 82, 191, 206, 217, 247, 194, 164, 121, 99, 108, 150, 186, 243, 6, 145, 167, 185, 149, 252, 77, 64, 119, 22, 209, 11, 146, 122, 91, 134, 103, 31, 4, 80, 234, 146, 135, 137, 205, 5, 10, 44, 111, 0, 7, 73, 235, 23, 160, 238, 128, 211, 174, 227, 103, 66, 60, 234, 27, 195, 184, 50, 97, 23, 174, 89, 221, 44, 42, 226, 109, 122, 126, 91, 110, 4, 28, 79, 253, 189, 6, 159, 166, 229, 218, 2, 31, 114, 209, 175, 92, 211, 175, 92, 180, 196, 58, 249, 73, 21, 140, 64, 217, 171, 14, 129, 14, 76, 226, 105, 207, 168, 74, 83, 13, 79, 75, 18, 222, 101, 66, 223, 14, 207, 186, 34, 234, 76, 143, 145, 212, 53, 224, 157, 17, 180, 142, 163, 36, 4, 237, 71, 231, 33, 141, 46, 146, 233, 229, 206, 67, 167, 228, 80, 16, 169, 174, 241, 209, 152, 34, 242, 204, 197, 247, 254, 19, 22, 177, 50, 104, 250, 46, 236, 69, 98, 253, 118, 11, 67, 108, 60, 63, 73, 14, 147, 106, 158, 162, 139, 52, 143, 82, 81, 92, 12, 161, 158, 214, 4, 108 };


    // http://strongpasswordgenerator.com/
    // 100 characters, no programming symbols

    /// <summary>
    /// default Public key as string
    /// </summary>
    private const string DefaultPublicKey2Str = "BKkAqIak8aDpBa932dVRT;tDea0o0rucMMQlUxvdl-aKs6jjIgliklawgodwEJuZeImYvvVYZKNheInnLhEenfsIgvdX2bcr2cjr";

    #region PublicKey

    /// <summary>
    /// Public key container
    /// </summary>
    private static byte[] m_PublicKey;

    /// <summary>
    /// The public key (1024 bytes) (first half of public key)
    /// </summary>
    public static byte[] PublicKey
    {
        get
        {
            // if not set, then use the default
            return m_PublicKey ?? (m_PublicKey = DefaultPublicKey);
        }

        set
        {
            // if null, set to default
            if (value.IsNullOrEmpty())
            {
                m_PublicKey = DefaultPublicKey;
                return;
            }

            // throw exception if not 1024 bytes
            if (value.Length != 1024)
                throw new ArgumentOutOfRangeException("value", "PublicKey must be 1024 bytes");

            // set the value
            m_PublicKey = value;
        }
    }

    // PublicKey
    #endregion

    #region PublicKey2Str

    /// <summary>
    /// public key string container
    /// </summary>
    private static string m_PublicKey2Str = string.Empty;

    /// <summary>
    /// The public key string (second half of public key)
    /// </summary>
    public static string PublicKey2Str
    {
        get
        {
            // if null, set to default
            if (string.IsNullOrEmpty(m_PublicKey2Str))
                m_PublicKey2Str = DefaultPublicKey2Str;

            return m_PublicKey2Str;
        }
        set
        {
            // if null, set to default
            if (string.IsNullOrEmpty(value))
            {
                m_PublicKey2Str = DefaultPublicKey2Str;
                return;
            }

            // set value
            m_PublicKey2Str = value;
        }
    }

    // PublicKey2Str
    #endregion

    // Variables
    #endregion

    #region BuildAESKeys

    /// <summary>
    /// builds keys for the crypto
    /// </summary>
    /// <param name="RCrypto"></param>
    /// <param name="key">the key to build with</param>
    /// <param name="keyStr">the key string to build with</param>
    private static void BuildAESKeys(AesManaged RCrypto, string keyStr, byte[] key)
    {
        // set block and key size
        RCrypto.BlockSize = RCrypto.LegalBlockSizes[0].MaxSize;
        RCrypto.KeySize = RCrypto.LegalKeySizes[0].MaxSize;

        /*
            What the key derivation function (Rfc2898DeriveBytes) does is repeatedly hash the user password along with a salt. This has multiple benefits:

                1) you can use arbitrarily sized passwords – AES only supports specific key sizes.

                2) the addition of the salt means that you can use the same passphrase to generate multiple different. 
                    This is important for key separation; reusing keys in different contexts is one of the most common ways cryptographic systems are broken.

            The beauty of this is that every time you encrypt plain text P1 with the derived key, you will get a different cipher text out the other side. 
            But those different cipher texts can all be decrypted with the same key.
        */
        Rfc2898DeriveBytes KeyDerivationFunction = new Rfc2898DeriveBytes(keyStr, key);
        byte[] keyBytes = KeyDerivationFunction.GetBytes(32);
        KeyDerivationFunction.Reset();
        byte[] ivBytes = KeyDerivationFunction.GetBytes(16);

        // populate keys in crypto
        RCrypto.Key = keyBytes;
        RCrypto.IV = ivBytes;
    }

    // BuildAESKeys
    #endregion

    #region EncryptWithAES

    /// <summary>
    /// Encrypts source using the public keys
    /// </summary>
    /// <param name="source"></param>
    /// <returns></returns>
    public static byte[] EncryptStringWithAES(this string source)
    {
        return EncryptStringWithAES(source, PublicKey2Str, PublicKey);
    }

    /// <summary>
    /// Encrypts source
    /// </summary>
    /// <param name="source"></param>
    /// <param name="keyStr">string key</param>
    /// <param name="key">key</param>
    public static byte[] EncryptStringWithAES(this string source, string keyStr, byte[] key)
    {
        // convert to bytes, and encrypt
        return (!string.IsNullOrEmpty(source)) ?
            EncryptWithAES(source.UnityStringToBytes(), keyStr, key) :
            null;
    }

    /// <summary>
    /// Encrypts source using the public keys
    /// </summary>
    /// <param name="source"></param>
    /// <returns></returns>
    public static byte[] EncryptWithAES(this byte[] source)
    {
        return EncryptWithAES(source, PublicKey2Str, PublicKey);
    }

    /// <summary>
    /// Encrypts source
    /// </summary>
    /// <param name="source"></param>
    /// <param name="keyStr">string key</param>
    /// <param name="key">key</param>
    public static byte[] EncryptWithAES(this byte[] source, string keyStr, byte[] key)
    {
        // exit if null
        if (source.IsNullOrEmpty())
            return null;

        using (AesManaged RCrypto = new AesManaged())
        {
            BuildAESKeys(RCrypto, keyStr, key);
            ICryptoTransform REncryptor = RCrypto.CreateEncryptor(RCrypto.Key, RCrypto.IV);

            // encrypt with a crypto stream
            using (MemoryStream encMemStream = new MemoryStream())
            {
                using (CryptoStream cryptoStream = new CryptoStream(encMemStream, REncryptor, CryptoStreamMode.Write))
                {
                    // write and encrypt
                    cryptoStream.Write(source, 0, source.Length);
                    cryptoStream.FlushFinalBlock();

                    // return the array
                    return encMemStream.ToArray();
                }
            }
        }
    }

    // EncryptWithAES
    #endregion

    #region DecryptWithAES

    /// <summary>
    /// Decrypts source using the public keys
    /// </summary>
    /// <param name="source"></param>
    /// <returns></returns>
    public static byte[] DecryptWithAES(this byte[] source)
    {
        return DecryptWithAES(source, PublicKey2Str, PublicKey);
    }

    /// <summary>
    /// Decrypts source
    /// </summary>
    /// <param name="source"></param>
    /// <param name="key">the key to build with</param>
    /// <param name="keyStr">the key string to build with</param>
    public static byte[] DecryptWithAES(this byte[] source, string keyStr, byte[] key)
    {
        // exit if null
        if (source.IsNullOrEmpty())
            return null;

        using (AesManaged RCrypto = new AesManaged())
        {
            BuildAESKeys(RCrypto, keyStr, key);

            // Create a decrytor to perform the stream transform.
            ICryptoTransform RDecryptor = RCrypto.CreateDecryptor(RCrypto.Key, RCrypto.IV);

            // decrypt with a crypto stream
            // read from
            using (MemoryStream SourceMemStream = new MemoryStream(source))
            {
                // run through decryptor
                using (CryptoStream cryptoStream = new CryptoStream(SourceMemStream, RDecryptor, CryptoStreamMode.Read))
                {
                    // save to memory stream so we can get decrypted bytes
                    using (MemoryStream decMemStream = new MemoryStream())
                    {
                        byte[] buffer = new byte[512];
                        int bytesRead;

                        while ((bytesRead = cryptoStream.Read(buffer, 0, buffer.Length)) > 0)
                            decMemStream.Write(buffer, 0, bytesRead);

                        // get the decrypted data (still in byte form)
                        return decMemStream.ToArray();
                    }
                }
            }
        }
    }

    /// <summary>
    /// Decrypts source back to a string using public keys
    /// </summary>
    /// <param name="source"></param>
    /// <returns></returns>
    public static string DecryptWithAESToString(this byte[] source)
    {
        return DecryptWithAESToString(source, PublicKey2Str, PublicKey);
    }

    /// <summary>
    /// Decrypts source back to a string
    /// </summary>
    /// <param name="source"></param>
    /// <param name="key">the key to build with</param>
    /// <param name="keyStr">the key string to build with</param>
    public static string DecryptWithAESToString(this byte[] source, string keyStr, byte[] key)
    {
        return source.DecryptWithAES(keyStr, key).UnityBytesToString();
    }

    // DecryptWithAES
    #endregion


    // NOTE: Rijndael is NOT supported in WP8. If you want to use the Rijndael on 
    // other platforms, simply add a compiler directive of "UseRijndael", or 
    // comment out the if / endif lines
#if (UseRijndael)

    #region BuildRijndaelKeys

    /// <summary>
    /// builds keys for the crypto
    /// </summary>
    /// <param name="RCrypto"></param>
    /// <param name="key">the key to build with</param>
    /// <param name="keyStr">the key string to build with</param>
    private static void BuildRijndaelKeys(RijndaelManaged RCrypto, string keyStr, byte[] key)
    {
        // set block and key size
        RCrypto.BlockSize = RCrypto.LegalBlockSizes[0].MaxSize;
        RCrypto.KeySize = RCrypto.LegalKeySizes[0].MaxSize;

        /*
            What the key derivation function (Rfc2898DeriveBytes) does is repeatedly hash the user password along with a salt. This has multiple benefits:

                1) you can use arbitrarily sized passwords – AES only supports specific key sizes.

                2) the addition of the salt means that you can use the same passphrase to generate multiple different. 
                    This is important for key separation; reusing keys in different contexts is one of the most common ways cryptographic systems are broken.

            The beauty of this is that every time you encrypt plain text P1 with the derived key, you will get a different cipher text out the other side. 
            But those different cipher texts can all be decrypted with the same key.
        */
        Rfc2898DeriveBytes KeyDerivationFunction = new Rfc2898DeriveBytes(keyStr, key);

        // derive our key, and IV (Rijndael)
        byte[] keyBytes = KeyDerivationFunction.GetBytes(RCrypto.KeySize / 8);
        KeyDerivationFunction.Reset();
        byte[] ivBytes = KeyDerivationFunction.GetBytes(RCrypto.BlockSize / 8);

        // populate keys in crypto
        RCrypto.Key = keyBytes;
        RCrypto.IV = ivBytes;
        RCrypto.Mode = CipherMode.CBC;
        RCrypto.Padding = PaddingMode.PKCS7;
    }

    // BuildRijndaelKeys
    #endregion

    #region EncryptWithRijndael

    /// <summary>
    /// Encrypts source using the public keys
    /// </summary>
    /// <param name="source"></param>
    /// <returns></returns>
    public static byte[] EncryptWithRijndael(this string source)
    {
        return EncryptWithRijndael(source, PublicKey2Str, PublicKey);
    }

    /// <summary>
    /// Encrypts source
    /// </summary>
    /// <param name="source"></param>
    /// <param name="keyStr">string key</param>
    /// <param name="key">key</param>
    public static byte[] EncryptWithRijndael(this string source, string keyStr, byte[] key)
    {
        try
        {
            // convert to bytes, and encrypt
            return (!string.IsNullOrEmpty(source)) ?
                EncryptWithRijndael(source.UnityStringToBytes(), keyStr, key) :
                null;
        }

        catch (Exception excep)
        {
            ExceptionLogger.SaveException(excep, source);
        }

        return null;
    }

    /// <summary>
    /// Encrypts source using the public keys
    /// </summary>
    /// <param name="source"></param>
    /// <returns></returns>
    public static byte[] EncryptWithRijndael(this byte[] source)
    {
        return EncryptWithRijndael(source, PublicKey2Str, PublicKey);
    }

    /// <summary>
    /// Encrypts source
    /// </summary>
    /// <param name="source"></param>
    /// <param name="keyStr">string key</param>
    /// <param name="key">key</param>
    public static byte[] EncryptWithRijndael(this byte[] source, string keyStr, byte[] key)
    {
        try
        {
            // exit if null
            if (source.IsNullOrEmpty())
                return null;

            using (RijndaelManaged RCrypto = new RijndaelManaged())
            {
                BuildRijndaelKeys(RCrypto, keyStr, key);
                ICryptoTransform REncryptor = RCrypto.CreateEncryptor(RCrypto.Key, RCrypto.IV);

                // encrypt with a crypto stream
                using (MemoryStream encMemStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream(encMemStream, REncryptor, CryptoStreamMode.Write))
                    {
                        // write and encrypt
                        cryptoStream.Write(source, 0, source.Length);
                        cryptoStream.FlushFinalBlock();

                        // return the array
                        return encMemStream.ToArray();
                    }
                }
            }
        }

        catch (Exception excep)
        {
            ExceptionLogger.SaveException(excep, source);
        }

        return null;
    }

    // EncryptWithRijndael
    #endregion

    #region DecryptWithRijndael

    /// <summary>
    /// Decrypts source using the public keys
    /// </summary>
    /// <param name="source"></param>
    /// <returns></returns>
    public static byte[] DecryptWithRijndael(this byte[] source)
    {
        return DecryptWithRijndael(source, PublicKey2Str, PublicKey);
    }

    /// <summary>
    /// Decrypts source
    /// </summary>
    /// <param name="source"></param>
    /// <param name="key">the key to build with</param>
    /// <param name="keyStr">the key string to build with</param>
    public static byte[] DecryptWithRijndael(this byte[] source, string keyStr, byte[] key)
    {
        // exit if null
        if (source.IsNullOrEmpty())
            return null;

        try
        {
            using (RijndaelManaged RCrypto = new RijndaelManaged())
            {
                BuildRijndaelKeys(RCrypto, keyStr, key);

                // Create a decrytor to perform the stream transform.
                ICryptoTransform RDecryptor = RCrypto.CreateDecryptor(RCrypto.Key, RCrypto.IV);

                // decrypt with a crypto stream
                // read from
                using (MemoryStream SourceMemStream = new MemoryStream(source))
                {
                    // run through decryptor
                    using (CryptoStream cryptoStream = new CryptoStream(SourceMemStream, RDecryptor, CryptoStreamMode.Read))
                    {
                        // save to memory stream so we can get decrypted bytes
                        using (MemoryStream decMemStream = new MemoryStream())
                        {
                            byte[] buffer = new byte[512];
                            int bytesRead;

                            while ((bytesRead = cryptoStream.Read(buffer, 0, buffer.Length)) > 0)
                                decMemStream.Write(buffer, 0, bytesRead);

                            // get the decrypted data (still in byte form)
                            return decMemStream.ToArray();
                        }
                    }
                }
            }
        }

        catch (Exception excep)
        {
            ExceptionLogger.SaveException(excep, source);
        }

        return null;
    }

    /// <summary>
    /// Decrypts source back to a string using public keys
    /// </summary>
    /// <param name="source"></param>
    /// <returns></returns>
    public static string DecryptWithRijndaelToString(this byte[] source)
    {
        return DecryptWithRijndaelToString(source, PublicKey2Str, PublicKey);
    }

    /// <summary>
    /// Decrypts source back to a string
    /// </summary>
    /// <param name="source"></param>
    /// <param name="key">the key to build with</param>
    /// <param name="keyStr">the key string to build with</param>
    public static string DecryptWithRijndaelToString(this byte[] source, string keyStr, byte[] key)
    {
        return source.DecryptWithRijndael(keyStr, key).UnityBytesToString();
    }

    // DecryptWithRijndael
    #endregion

#endif
}