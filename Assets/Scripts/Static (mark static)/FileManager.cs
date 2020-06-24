using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using UnityEngine;

namespace SshModLoader
{
    public static class FileManager
    {
        public static void SaveAppBackup(string appName, List<FilePlus> files)
        {
            foreach (var file in files)
            {
                SaveFile(file.name, Path.Combine(Paths.local.GetAppBackup(appName), file.path), file.bytes);
            }
        }

        public static void SavePrefsBackup(string appName, List<FilePlus> files)
        {
            foreach (var file in files)
            {
                SaveFile(file.name, Path.Combine(Paths.local.GetPrefsBackup(appName), file.path), file.bytes);
            }
        }

        public static void SaveMod()
        {

        }

        private static void SaveFile(string fileName, string path, byte[] fileData)
        {
            var fullPath = Path.Combine(path, fileName);

            // Create the directory if it doesn't exist
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            // Delete the file if it exists.
            else if (File.Exists(fullPath))
                File.Delete(fullPath);

            using (FileStream fs = File.Create(fullPath))
            {
                fs.Write(fileData, 0, fileData.Length);
            }
        }

        private static byte[] LoadFile(string fullPath)
        {
            MemoryStream ms = new MemoryStream();

            if (File.Exists(fullPath))
            {
                using (FileStream fs = File.Open(fullPath, FileMode.Open))
                {
                    fs.CopyTo(ms);
                }

                return ms.ToArray();
            }
            else
            {
                Debug.LogError("Error: File not found in " + fullPath);
                return null;
            }
        }
    }
}
