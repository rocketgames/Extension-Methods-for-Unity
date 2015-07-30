using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using UnityEngine;

/* *****************************************************************************
 * File:    UnityXMLSerializationExtensions.cs
 * Author:  Philip Pierce - Thursday, October 02, 2014
 * Description:
 *  Handles XML serializing and deserializing unity data
 *  See: http://wiki.unity3d.com/index.php?title=Saving_and_Loading_Data:_XmlSerializer
 *  
 * History:
 *  Thursday, October 02, 2014 - Created
 * ****************************************************************************/

/// <summary>
/// Handles XML serializing and deserializing unity data
/// </summary>
public static class UnityXMLSerializationExtensions 
{
    #region XMLSerialize

    /// <summary>
    /// XML Serializes an object and returns a byte array
    /// </summary>
    /// <param name="objToSerialize">the object to serialize</param>
    public static byte[] XMLSerialize_ToArray<T>(this T objToSerialize) where T : class
    {
        if (objToSerialize.IsTNull())
            return null;

        // create the serialization object
        XmlSerializer xSerializer = new XmlSerializer(objToSerialize.GetType());

        // create a textwriter to hold the output
        using (MemoryStream ms = new MemoryStream())
        {
            using (XmlTextWriter xtw = new XmlTextWriter(ms, Encoding.Unicode))
            {
                // serialize it
                xSerializer.Serialize(xtw, objToSerialize);

                // return it
                return ((MemoryStream)xtw.BaseStream).ToArray();
            }
        }
    }

    /// <summary>
    /// XML Serializes an object and returns the serialized string
    /// </summary>
    /// <param name="objToSerialize">the object to serialize</param>
    public static string XMLSerialize_ToString<T>(this T objToSerialize) where T : class
    {
        // exit if null
        if (objToSerialize.IsTNull())
            return null;

        // create the serialization object
        XmlSerializer xSerializer = new XmlSerializer(objToSerialize.GetType());

        // create a textwriter to hold the output
        using (MemoryStream ms = new MemoryStream())
        {
            using (XmlTextWriter xtw = new XmlTextWriter(ms, Encoding.Unicode))
            {
                // serialize it
                xSerializer.Serialize(xtw, objToSerialize);

                // return it
                return UnicodeEncoding.Unicode.GetString(((MemoryStream)xtw.BaseStream).ToArray());
            }
        }
    }

    // XMLSerialize
    #endregion

    #region XMLDeserialize

    /// <summary>
    /// Deserializes an XML string
    /// </summary>
    /// <param name="strSerial">the string to deserialize</param>
    /// <returns></returns>
    public static T XMLDeserialize_ToObject<T>(this string strSerial) where T : class
    {
        // skip if no string
        if (string.IsNullOrEmpty(strSerial))
            return default(T);

        using (MemoryStream ms = new MemoryStream(UnicodeEncoding.Unicode.GetBytes(strSerial)))
        {
            // create the serialization object
            XmlSerializer xSerializer = new XmlSerializer(typeof(T));

            // deserialize it
            return (T)xSerializer.Deserialize(ms);
        }
    }

    /// <summary>
    /// XML Deserializes a string
    /// </summary>
    /// <param name="objSerial">the object to deserialize</param>
    /// <returns></returns>
    public static T XMLDeserialize_ToObject<T>(byte[] objSerial) where T : class
    {
        // skip if no object
        if (objSerial.IsNullOrEmpty())
            return default(T);

        // pop the memory string
        using (MemoryStream ms = new MemoryStream(objSerial))
        {
            // create the serialization object
            XmlSerializer xSerializer = new XmlSerializer(typeof(T));

            // deserialize it
            return (T)xSerializer.Deserialize(ms);
        }
    }

    // XMLDeserialize
    #endregion

    #region XMLSerialize_AndSaveTo
    
    /// <summary>
    /// XML Serialize the object, and save it to a file
    /// </summary>
    /// <param name="objToSerialize"></param>
    /// <param name="path"></param>
    public static void XMLSerialize_AndSaveTo<T>(this T objToSerialize, string path) where T : class
    {
        // exit if null
        if ((objToSerialize.IsTNull()) || (path.IsNullOrEmpty()))
            return;

        // create the directory if it doesn't exist
        path.CreateDirectoryIfNotExists();

        // get a serialized on the object
        XmlSerializer serializer = new XmlSerializer(objToSerialize.GetType());

        // write to a filestream
        using (FileStream fs = new FileStream(path, FileMode.Create))
            serializer.Serialize(fs, objToSerialize);
    }

    // XMLSerialize_AndSaveTo
    #endregion

    #region XMLSerialize_AndSaveToPersistentDataPath

    /// <summary>
    /// XML Serialize the object, and save it to the PersistentDataPath, which is a directory where your application can store user specific 
    /// data on the target computer. This is a recommended way to store files locally for a user like highscores or savegames. 
    /// </summary>
    /// <param name="objToSerialize"></param>
    /// <param name="folderName">OPTIONAL - sub folder name (ex. DataFiles\SavedGames</param>
    /// <param name="filename">the filename (ex. SavedGameData.xml)</param>
    public static void XMLSerialize_AndSaveToPersistentDataPath<T>(this T objToSerialize, string folderName, string filename) where T : class
    {
        // exit if null
        if ((objToSerialize.IsTNull()) || (filename.IsNullOrEmpty()))
            return;

        // build the path
        string path = folderName.IsNullOrEmpty() ?
            Path.Combine(Application.persistentDataPath, filename) :
            Path.Combine(Path.Combine(Application.persistentDataPath, folderName), filename);

        // create the directory if it doesn't exist
        path.CreateDirectoryIfNotExists();

        // get a serialized on the object
        XmlSerializer serializer = new XmlSerializer(objToSerialize.GetType());

        // write to a filestream
        using (FileStream fs = new FileStream(path, FileMode.Create))
            serializer.Serialize(fs, objToSerialize);
    }

    // XMLSerialize_AndSaveToPersistentDataPath
    #endregion

    #region XMLSerialize_AndSaveToDataPath

    /// <summary>
    /// XML Serialize the object, and save it to the DataPath, which points to your asset/project directory. This directory is typically read-only after
    /// your game has been compiled. Use only from Editor scripts
    /// </summary>
    /// <param name="objToSerialize"></param>
    /// <param name="folderName">OPTIONAL - sub folder name (ex. DataFiles\SavedGames</param>
    /// <param name="filename">the filename (ex. SavedGameData.xml)</param>
    public static void XMLSerialize_AndSaveToDataPath<T>(this T objToSerialize, string folderName, string filename) where T : class
    {
        // exit if null
        if ((objToSerialize.IsTNull()) || (filename.IsNullOrEmpty()))
            return;

        // build the path
        string path = folderName.IsNullOrEmpty() ?
            Path.Combine(Application.persistentDataPath, filename) :
            Path.Combine(Path.Combine(Application.persistentDataPath, folderName), filename);

        // create the directory if it doesn't exist
        path.CreateDirectoryIfNotExists();

        // get a serialized on the object
        XmlSerializer serializer = new XmlSerializer(objToSerialize.GetType());

        // write to a filestream
        using (FileStream fs = new FileStream(path, FileMode.Create))
            serializer.Serialize(fs, objToSerialize);
    }

    // XMLSerialize_AndSaveToDataPath
    #endregion

    #region XMLDeserialize_AndLoadFrom

    /// <summary>
    /// Load from a file and XML deserialize the object
    /// </summary>
    /// <param name="path"></param>
    public static T XMLDeserialize_AndLoadFrom<T>(this string path) where T : class
    {
        // exit if null
        if (path.IsNullOrEmpty())
            return null;

        // exit if the file doesn't exist
        if (!File.Exists(path))
            return null;

        // get the serializer
        XmlSerializer serializer = new XmlSerializer(typeof(T));
        using (FileStream fs = new FileStream(path, FileMode.Open))
            return serializer.Deserialize(fs) as T;
    }

    // XMLDeserialize_AndLoadFrom
    #endregion

    #region XMLDeserialize_AndLoadFromPersistentDataPath

    /// <summary>
    /// Load from a file and XML deserialize the object
    /// </summary>
    /// <param name="folderName">OPTIONAL - sub folder name (ex. DataFiles\SavedGames</param>
    /// <param name="filename">the filename (ex. SavedGameData.xml)</param>
    public static T XMLDeserialize_AndLoadFromPersistentDataPath<T>(this string filename, string folderName) where T : class
    {
        // exit if null
        if (filename.IsNullOrEmpty())
            return null;

        // build the path
        string path = folderName.IsNullOrEmpty() ?
            Path.Combine(Application.persistentDataPath, filename) :
            Path.Combine(Path.Combine(Application.persistentDataPath, folderName), filename);

        // load
        return path.XMLDeserialize_AndLoadFrom<T>();
    }

    // XMLDeserialize_AndLoadFromPersistentDataPath
    #endregion

    #region XMLDeserialize_AndLoadFromDataPath

    /// <summary>
    /// Load from a file and XML deserialize the object
    /// </summary>
    /// <param name="folderName">OPTIONAL - sub folder name (ex. DataFiles\SavedGames</param>
    /// <param name="filename">the filename (ex. SavedGameData.xml)</param>
    public static T XMLDeserialize_AndLoadFromDataPath<T>(this string filename, string folderName) where T : class
    {
        // exit if null
        if (filename.IsNullOrEmpty())
            return null;

        // build the path
        string path = folderName.IsNullOrEmpty() ?
            Path.Combine(Application.dataPath, filename) :
            Path.Combine(Path.Combine(Application.dataPath, folderName), filename);

        // load
        return path.XMLDeserialize_AndLoadFrom<T>();
    }

    // XMLDeserialize_AndLoadFromDataPath
    #endregion
}