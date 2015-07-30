using System.IO;
using UnityEngine;

/* *****************************************************************************
 * File:    UnityFileExtensions.cs
 * Author:  Philip Pierce - Friday, October 03, 2014
 * Description:
 *  Extensions for reading and saving files in Unity
 *  
 * History:
 *  Friday, October 03, 2014 - Created
 * ****************************************************************************/

/// <summary>
/// Extensions for reading and saving files in Unity
/// </summary>
public static class UnityFileExtensions
{
    #region SaveTo

    /// <summary>
    /// Saves the data to a file
    /// </summary>
    /// <param name="data"></param>
    /// <param name="path"></param>
    public static void SaveTo(this string data, string path)
    {
        // exit if no data or no filename
        if ((data.IsNullOrEmpty()) || (path.IsNullOrEmpty()))
            return;

        // create the folder if it doesn't exist
        path.CreateDirectoryIfNotExists();

        // save the data
        File.WriteAllText(data, path);
    }

    /// <summary>
    /// Saves the data to a file
    /// </summary>
    /// <param name="data"></param>
    /// <param name="path"></param>
    public static void SaveTo(this byte[] data, string path)
    {
        // exit if no data or no filename
        if ((data.IsNullOrEmpty()) || (path.IsNullOrEmpty()))
            return;

        // create the folder if it doesn't exist
        path.CreateDirectoryIfNotExists();

        // save the data
        File.WriteAllBytes(path, data);
    }

    // SaveTo
    #endregion

    #region SaveToPersistentDataPath

    /// <summary>
    /// Saves the data to the PersistentDataPath, which is a directory where your application can store user specific 
    /// data on the target computer. This is a recommended way to store files locally for a user like highscores or savegames. 
    /// </summary>
    /// <param name="data">data to save</param>
    /// <param name="folderName">OPTIONAL - sub folder name (ex. DataFiles\SavedGames</param>
    /// <param name="filename">the filename (ex. SavedGameData.xml)</param>
    public static void SaveToPersistentDataPath(this string data, string folderName, string filename)
    {
        // exit if no data or no filename
        if ((data.IsNullOrEmpty()) || (filename.IsNullOrEmpty()))
            return;

        string path = folderName.IsNullOrEmpty() ?
            Path.Combine(Application.persistentDataPath, filename) :
            Path.Combine(Path.Combine(Application.persistentDataPath, folderName), filename);

        // save the data
        SaveTo(data, path);
    }

    /// <summary>
    /// Saves the data to the PersistentDataPath, which is a directory where your application can store user specific 
    /// data on the target computer. This is a recommended way to store files locally for a user like highscores or savegames. 
    /// </summary>
    /// <param name="data">data to save</param>
    /// <param name="folderName">OPTIONAL - sub folder name (ex. DataFiles\SavedGames</param>
    /// <param name="filename">the filename (ex. SavedGameData.xml)</param>
    public static void SaveToPersistentDataPath(this byte[] data, string folderName, string filename)
    {
        // exit if no data or no filename
        if ((data.IsNullOrEmpty()) || (filename.IsNullOrEmpty()))
            return;

        string path = folderName.IsNullOrEmpty() ?
            Path.Combine(Application.persistentDataPath, filename) :
            Path.Combine(Path.Combine(Application.persistentDataPath, folderName), filename);

        // save the data
        SaveTo(data, path);
    }

    // SaveToPersistentDataPath
    #endregion

    #region SaveToDataPath

    /// <summary>
    /// Saves the data to the DataPath, which points to your asset/project directory. This directory is typically read-only after
    /// your game has been compiled. Use SaveToDataPath only from Editor scripts
    /// </summary>
    /// <param name="data">data to save</param>
    /// <param name="folderName">OPTIONAL - sub folder name (ex. DataFiles\SavedGames</param>
    /// <param name="filename">the filename (ex. SavedGameData.xml)</param>
    public static void SaveToDataPath(this string data, string folderName, string filename)
    {
        // exit if no data or no filename
        if ((data.IsNullOrEmpty()) || (filename.IsNullOrEmpty()))
            return;

        string path = folderName.IsNullOrEmpty() ?
            Path.Combine(Application.dataPath, filename) :
            Path.Combine(Path.Combine(Application.dataPath, folderName), filename);

        // save the data
        SaveTo(data, path);
    }

    /// <summary>
    /// Saves the data to the DataPath, which points to your asset/project directory. This directory is typically read-only after
    /// your game has been compiled. Use SaveToDataPath only from Editor scripts
    /// </summary>
    /// <param name="data">data to save</param>
    /// <param name="folderName">OPTIONAL - sub folder name (ex. DataFiles\SavedGames</param>
    /// <param name="filename">the filename (ex. SavedGameData.xml)</param>
    public static void SaveToDataPath(this byte[] data, string folderName, string filename)
    {
        // exit if no data or no filename
        if ((data.IsNullOrEmpty()) || (filename.IsNullOrEmpty()))
            return;

        string path = folderName.IsNullOrEmpty() ?
            Path.Combine(Application.dataPath, filename) :
            Path.Combine(Path.Combine(Application.dataPath, folderName), filename);

        // save the data
        SaveTo(data, path);
    }

    // SaveToDataPath
    #endregion

    #region LoadFrom

    /// <summary>
    /// Loads the data as a string 
    /// </summary>
    /// <param name="path"></param>
    /// <returns></returns>
    public static string LoadFrom_AsString(this string path)
    {
        // exit if no path
        if (path.IsNullOrEmpty())
            return null;

        // exit if the file doesn't exist
        if (!File.Exists(path))
            return null;

        // read the file
        return File.ReadAllText(path);
    }

    /// <summary>
    /// Loads the data as a byte array 
    /// </summary>
    /// <param name="path"></param>
    /// <returns></returns>
    public static byte[] LoadFrom_AsBytes(this string path)
    {
        // exit if no path
        if (path.IsNullOrEmpty())
            return null;

        // exit if the file doesn't exist
        if (!File.Exists(path))
            return null;

        // read the file
        return File.ReadAllBytes(path);
    }

    // LoadFrom
    #endregion

    #region LoadFromPeristantDataPath

    /// <summary>
    /// Loads the data from PersistantDataPath as a string 
    /// </summary>
    /// <param name="folderName">OPTIONAL - sub folder name (ex. DataFiles\SavedGames</param>
    /// <param name="filename">the filename (ex. SavedGameData.xml)</param>
    public static string LoadFromPeristantDataPath_AsString(this string filename, string folderName)
    {
        // exit if no path
        if (filename.IsNullOrEmpty())
            return null;

        // build the path
        string path = folderName.IsNullOrEmpty() ?
            Path.Combine(Application.persistentDataPath, filename) :
            Path.Combine(Path.Combine(Application.persistentDataPath, folderName), filename);

        // load the data
        return LoadFrom_AsString(path);
    }

    /// <summary>
    /// Loads the data from PersistantDataPath as a byte array 
    /// </summary>
    /// <param name="folderName">OPTIONAL - sub folder name (ex. DataFiles\SavedGames</param>
    /// <param name="filename">the filename (ex. SavedGameData.xml)</param>
    public static byte[] LoadFromPeristantDataPath_AsBytes(this string filename, string folderName)
    {
        // exit if no path
        if (filename.IsNullOrEmpty())
            return null;

        // build the path
        string path = folderName.IsNullOrEmpty() ?
            Path.Combine(Application.persistentDataPath, filename) :
            Path.Combine(Path.Combine(Application.persistentDataPath, folderName), filename);

        // load the data
        return LoadFrom_AsBytes(path);
    }

    // LoadFromPeristantDataPath
    #endregion

    #region LoadFromDataPath

    /// <summary>
    /// Loads the data from PersistantDataPath as a string 
    /// </summary>
    /// <param name="folderName">OPTIONAL - sub folder name (ex. DataFiles\SavedGames</param>
    /// <param name="filename">the filename (ex. SavedGameData.xml)</param>
    public static string LoadFromDataPath_AsString(this string filename, string folderName)
    {
        // exit if no path
        if (filename.IsNullOrEmpty())
            return null;

        // build the path
        string path = folderName.IsNullOrEmpty() ?
            Path.Combine(Application.dataPath, filename) :
            Path.Combine(Path.Combine(Application.dataPath, folderName), filename);

        // load the data
        return LoadFrom_AsString(path);
    }

    /// <summary>
    /// Loads the data from PersistantDataPath as a byte array 
    /// </summary>
    /// <param name="folderName">OPTIONAL - sub folder name (ex. DataFiles\SavedGames</param>
    /// <param name="filename">the filename (ex. SavedGameData.xml)</param>
    public static byte[] LoadFromDataPath_AsBytes(this string filename, string folderName)
    {
        // exit if no path
        if (filename.IsNullOrEmpty())
            return null;

        // build the path
        string path = folderName.IsNullOrEmpty() ?
            Path.Combine(Application.dataPath, filename) :
            Path.Combine(Path.Combine(Application.dataPath, folderName), filename);

        // load the data
        return LoadFrom_AsBytes(path);
    }

    // LoadFromDataPath
    #endregion
}