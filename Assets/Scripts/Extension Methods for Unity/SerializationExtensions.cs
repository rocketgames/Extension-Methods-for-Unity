using System;
using System.Globalization;
using System.IO;
using UnityEngine;

/* *****************************************************************************
 * File:    SerializationExtensions.cs
 * Author:  Philip Pierce - Thursday, July 17, 2014
 * Description:
 *  Handles serialization extensions
 *  
 * History:
 *  Thursday, July 17, 2014 - Created
 * ****************************************************************************/

/// <summary>
/// Handles serialization extensions
/// </summary>
public static class SerializationExtensions
{
    #region ToStringSerial

    /// <summary>
    /// Converts a string for serialization
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static string ToStringSerial(this string str)
    {
        return (!string.IsNullOrEmpty(str)) ?
            str.ToString(CultureInfo.InvariantCulture) :
            string.Empty.ToString(CultureInfo.InvariantCulture);
    }

    /// <summary>
    /// Converts a GUID? for string serialization
    /// </summary>
    /// <param name="guid"></param>
    /// <returns></returns>
    public static string ToStringSerial(this Guid? guid)
    {
        // return empty string or guid converted
        return (guid.HasValue) ? 
            guid.Value.ToStringSerial() : 
            new byte[0].ToBase64();
    }

    /// <summary>
    /// Converts a GUID for string serialization
    /// </summary>
    /// <param name="guid"></param>
    /// <returns></returns>
    public static string ToStringSerial(this Guid guid)
    {
        return guid.ToByteArray().ToBase64();
    }

    // ToStringSerial
    #endregion

    #region FromSerial

    /// <summary>
    /// Converts a string back to a Guid
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static Guid? GuidNullableFromSerialString(this string str)
    {
        // parse into a guid
        return (string.IsNullOrEmpty(str)) ? null : new Guid?(new Guid(str.FromBase64()));
    }

    /// <summary>
    /// Converts a string back to a Guid
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static Guid GuidFromSerialString(this string str)
    {
        // parse into a guid
        return (string.IsNullOrEmpty(str)) ? default(Guid) : new Guid(str.FromBase64());
    }

    // FromSerial
    #endregion

    #region Binary_Reader_Writer
    
    #region WriteByteArray

    /// <summary>
    /// Writes a byte array to a binary writer
    /// </summary>
    /// <param name="data"></param>
    /// <param name="bw"></param>
    public static BinaryWriter WriteByteArray(this BinaryWriter bw, byte[] data)
    {
        if (data.IsNullOrEmpty())
            bw.Write(0);
        else
        {
            bw.Write(data.Length);
            bw.Write(data);
        }

        return bw;
    }

    // WriteByteArray
    #endregion

    #region ReadbByteArray

    /// <summary>
    /// Reads a byte array from a binary reader
    /// </summary>
    /// <param name="bread"></param>
    /// <returns></returns>
    public static byte[] ReadbByteArray(this BinaryReader bread)
    {
        // get len
        int len = bread.ReadInt32();

        // read and return
        return (len == 0) ?
            null :
            bread.ReadBytes(len);
    }

    // ReadbByteArray
    #endregion

    #region WriteByteArrayCompressed

    /// <summary>
    /// Writes a compressed byte array to a binary writer
    /// </summary>
    /// <param name="data"></param>
    /// <param name="bw"></param>
    public static BinaryWriter WriteByteArrayCompressed(this BinaryWriter bw, byte[] data)
    {
        return bw.WriteByteArray(data.CompressBytes());
    }

    // WriteByteArrayCompressed
    #endregion

    #region ReadbByteArrayCompressed

    /// <summary>
    /// Reads a compressed byte array from a binary reader
    /// </summary>
    /// <param name="bread"></param>
    /// <returns></returns>
    public static byte[] ReadbByteArrayCompressed(this BinaryReader bread)
    {
        return bread.ReadbByteArray().DecompressBytes();
    }

    // ReadbByteArrayCompressed
    #endregion

    #region WriteGuid

    /// <summary>
    /// Writes a guid to a binary array, conserving serialization
    /// </summary>
    /// <param name="guid"></param>
    /// <param name="bw"></param>
    /// <returns></returns>
    public static BinaryWriter WriteGuid(this BinaryWriter bw, Guid? guid)
    {
        bw.Write(guid.ToStringSerial());
        return bw;
    }

    /// <summary>
    /// Writes a guid to a binary array, conserving serialization
    /// </summary>
    /// <param name="guid"></param>
    /// <param name="bw"></param>
    /// <returns></returns>
    public static BinaryWriter WriteGuid(this BinaryWriter bw, Guid guid)
    {
        bw.Write(guid.ToStringSerial());
        return bw;
    }

    // WriteGuid
    #endregion

    #region ReadGuid

    /// <summary>
    /// Returns a nullable guid
    /// </summary>
    /// <param name="bread"></param>
    /// <returns></returns>
    public static Guid? ReadGuidNullable(this BinaryReader bread)
    {
        return bread.ReadString().GuidNullableFromSerialString();
    }

    /// <summary>
    /// Returns a guid
    /// </summary>
    /// <param name="bread"></param>
    /// <returns></returns>
    public static Guid ReadGuid(this BinaryReader bread)
    {
        return bread.ReadString().GuidFromSerialString();
    }

    // ReadGuid
    #endregion

    #region WriteString

    /// <summary>
    /// Writes an invariant culture string
    /// </summary>
    /// <param name="source"></param>
    /// <param name="bw"></param>
    /// <returns></returns>
    public static BinaryWriter WriteSerializedString(this BinaryWriter bw, string source)
    {
        bw.Write(source.ToStringSerial());
        return bw;
    }

    // WriteString
    #endregion

    #region WriteDateTime

    /// <summary>
    /// Writes the date time to a binary writer (in UTC format)
    /// </summary>
    /// <param name="time"></param>
    /// <param name="bw"></param>
    /// <returns></returns>
    public static BinaryWriter WriteDateTime(this BinaryWriter bw, DateTime time)
    {
        bw.Write(TimeZoneInfo.ConvertTimeToUtc(time).Ticks);
        return bw;
    }

    // WriteDateTime
    #endregion

    #region ReadDateTime

    /// <summary>
    /// Reads the date time stored, in UTF format
    /// </summary>
    /// <param name="bread"></param>
    /// <returns></returns>
    public static DateTime ReadDateTimeAsUTC(this BinaryReader bread)
    {
        return new DateTime(bread.ReadInt64());
    }

    // ReadDateTime
    #endregion

    #region ReadDateTimeAsLocalTime

    /// <summary>
    /// Reads the date time stored, and returns in local time (following all local time zone rules)
    /// </summary>
    /// <param name="bread"></param>
    /// <returns></returns>
    public static DateTime ReadDateTimeAsLocalTime(this BinaryReader bread)
    {
        return new DateTime(bread.ReadInt64()).ToLocalTime();
    }

    // ReadDateTimeAsLocalTime
    #endregion

    #region WriteInt

    /// <summary>
    /// Writes an int
    /// </summary>
    /// <param name="bw"></param>
    /// <param name="val"></param>
    /// <returns></returns>
    public static BinaryWriter WriteInt(this BinaryWriter bw, int val)
    {
        bw.Write(val);
        return bw;
    }

    // WriteInt
    #endregion

    #region WriteLong

    /// <summary>
    /// Writes a long
    /// </summary>
    /// <param name="bw"></param>
    /// <param name="val"></param>
    /// <returns></returns>
    public static BinaryWriter WriteLong(this BinaryWriter bw, long val)
    {
        bw.Write(val);
        return bw;
    }

    // WriteLong
    #endregion

    #region WriteFloat

    /// <summary>
    /// Writes a float value
    /// </summary>
    /// <param name="bw"></param>
    /// <param name="val"></param>
    /// <returns></returns>
    public static BinaryWriter WriteFloat(this BinaryWriter bw, float val)
    {
        bw.Write(val);
        return bw;
    }

    // WriteFloat
    #endregion

    #region WriteVector3

    /// <summary>
    /// Writes a vector 3
    /// </summary>
    /// <param name="bw"></param>
    /// <param name="v3"></param>
    /// <returns></returns>
    public static BinaryWriter WriteVector3(this BinaryWriter bw, Vector3 v3)
    {
        bw.Write(v3.x);
        bw.Write(v3.y);
        bw.Write(v3.z);
        return bw;
    }

    // WriteVector3
    #endregion

    #region WriteVector2

    /// <summary>
    /// Writes a vector 3
    /// </summary>
    /// <param name="bw"></param>
    /// <param name="v2"></param>
    /// <returns></returns>
    public static BinaryWriter WriteVector2(this BinaryWriter bw, Vector2 v2)
    {
        bw.Write(v2.x);
        bw.Write(v2.y);
        return bw;
    }

    // WriteVector2
    #endregion

    #region ReadVector3

    /// <summary>
    /// Reads a Vector3
    /// </summary>
    /// <param name="bread"></param>
    /// <returns></returns>
    public static Vector3 ReadVector3(this BinaryReader bread)
    {
        return new Vector3(bread.ReadSingle(), bread.ReadSingle(), bread.ReadSingle());
    }

    // ReadVector3
    #endregion

    #region ReadVector2

    /// <summary>
    /// Reads a Vector2
    /// </summary>
    /// <param name="bread"></param>
    /// <returns></returns>
    public static Vector2 ReadVector2(this BinaryReader bread)
    {
        return new Vector2(bread.ReadSingle(), bread.ReadSingle());
    }

    // ReadVector2
    #endregion

    #region WriteBool

    /// <summary>
    /// Writes a bool
    /// </summary>
    /// <param name="bw"></param>
    /// <param name="val"></param>
    /// <returns></returns>
    public static BinaryWriter WriteBool(this BinaryWriter bw, bool val)
    {
        bw.Write(val);
        return bw;
    }

    // WriteBool
    #endregion

    // Binary_Reader_Writer
    #endregion
}