using System.IO;

/* *****************************************************************************
 * File:    FileExtensions.cs
 * Author:  Philip Pierce - Friday, October 03, 2014
 * Description:
 *  File IO extensions
 *  
 * History:
 *  Friday, October 03, 2014 - Created
 * ****************************************************************************/

/// <summary>
/// File IO extensions
/// </summary>
public static class FileExtensions
{
    #region CreateDirectoryIfNotExists

    /// <summary>
    /// Creates a directory at <paramref name="folder"/> if it doesn't exist
    /// </summary>
    /// <param name="folder"></param>
    public static void CreateDirectoryIfNotExists(this string folder)
    {
        if (folder.IsNullOrEmpty())
            return;

        string path = Path.GetDirectoryName(folder);
        if (path.IsNullOrEmpty())
            return;

        if (! Directory.Exists(path))
            Directory.CreateDirectory(path);
    }

    // CreateDirectoryIfNotExists
    #endregion
}