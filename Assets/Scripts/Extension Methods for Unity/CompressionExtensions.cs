using System.IO;
using ICSharpCode.SharpZipLib.BZip2;

/* *****************************************************************************
 * File:    CompressionExtensions.cs
 * Author:  Philip Pierce - Monday, September 29, 2014
 * Description:
 *  Unity Safe Extension for compressing data
 *  
 * History:
 *  Monday, September 29, 2014 - Created
 * ****************************************************************************/

/// <summary>
/// Unity Safe Extension for compressing data
/// </summary>
public static class CompressionExtensions
{
    /*
     *  String - CompressString() > DecompressString()
     *  String - ComrpessStringToBytes() > DecompressStringFromBytes()
     *  
     *  Bytes - CompressBytes() > DecompressBytes()
     *  Bytes - CompressBytesToString() > DecompressBytesFromString()
    */

    #region CompressBytes

    /// <summary>
    /// Compresses a byte array
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    public static byte[] CompressBytes(this byte[] data)
    {
        // empty if null
        if (data.IsNullOrEmpty())
            return null;

        using (MemoryStream msBZip2 = new MemoryStream())
        {
            int size = data.Length;

            // Prepend the compressed data with the length of the uncompressed data (firs 4 bytes)
            using (BinaryWriter writer = new BinaryWriter(msBZip2))
            {
                writer.Write(size);

                using (BZip2OutputStream BZip2OutStream = new BZip2OutputStream(msBZip2))
                {
                    BZip2OutStream.Write(data, 0, size);
                }
            }

            // return the compressed data
            return msBZip2.ToArray();
        }
    }

    /// <summary>
    /// Compresses a byte array and returns as a string
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    public static string CompressBytesToString(this byte[] data)
    {
        return data.CompressBytes().UnityBytesToString();
    }

    // CompressBytes
    #endregion

    #region CompressString

    /// <summary>
    /// Compresses a string and returns a string
    /// </summary>
    /// <param name="sBuffer"></param>
    /// <returns></returns>
    public static string CompressString(this string sBuffer)
    {
        return sBuffer.UnityStringToBytes().CompressBytesToString();
    }

    /// <summary>
    /// Compresses a string and returns a byte array
    /// </summary>
    /// <param name="sBuffer"></param>
    /// <returns></returns>
    public static byte[] CompressStringToBytes(this string sBuffer)
    {
        return sBuffer.UnityStringToBytes().CompressBytes();
    }

    // CompressString
    #endregion

    #region DecompressBytes

    /// <summary>
    /// Decompresses a compressed string to a byte array
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    public static byte[] DecompressBytes(this byte[] data)
    {
        // exit if null
        if (data.IsNullOrEmpty())
            return null;

        using (MemoryStream msBZip2 = new MemoryStream(data))
        {
            // read final uncompressed string size stored in first 4 bytes
            using (BinaryReader reader = new BinaryReader(msBZip2))
            {
                int size = reader.ReadInt32();

                using (BZip2InputStream m_isBZip2 = new BZip2InputStream(msBZip2))
                {
                    byte[] bytesUncompressed = new byte[size];
                    m_isBZip2.Read(bytesUncompressed, 0, size);
                    return bytesUncompressed;
                }
            }
        }
    }

    /// <summary>
    /// Decompresses a compressed string to a byte array
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    public static byte[] DecompressBytesFromString(this string data)
    {
        return data.UnityStringToBytes().DecompressBytes();
    }

    // DecompressBytes
    #endregion

    #region DecompressString

    /// <summary>
    /// Decompresses a compressed string
    /// </summary>
    /// <param name="sBuffer"></param>
    /// <returns></returns>
    public static string DecompressStringFromBytes(this byte[] sBuffer)
    {
        return sBuffer.DecompressBytes().UnityBytesToString();
    }

    /// <summary>
    /// Decompresses a compressed string
    /// </summary>
    /// <param name="sBuffer"></param>
    /// <returns></returns>
    public static string DecompressString(this string sBuffer)
    {
        return sBuffer.DecompressBytesFromString().UnityBytesToString();
    }

    // DecompressString
    #endregion
}