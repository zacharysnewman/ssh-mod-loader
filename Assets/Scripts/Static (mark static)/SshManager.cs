using System.Xml;
using System;
////////////////////////////////////////////////////////////////////////////////////
/// UploadDirectory method found here: 
/// https://stackoverflow.com/questions/39397746/ssh-net-upload-whole-folder
///
/// ListDirectory method found here:
/// https://stackoverflow.com/questions/13572889/ssh-net-sftp-get-a-list-of-directories-and-files-recursively
////////////////////////////////////////////////////////////////////////////////////

using System.IO;
using System.Net;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Renci.SshNet;
using Renci.SshNet.Sftp;

namespace SshModLoader
{
    public class SshManager : MonoBehaviour
    {
        [Tooltip("Your iOS WiFi IP Address")]
        public string ipAddress = "192.168.0.14";

        [Tooltip("'root' is the default value")]
        public string user = "root";

        [Tooltip("'alpine' is the default password")]
        public string password = "alpine";

        public List<App> remoteApps = new List<App>();
        public LoadingBar loadingBar;

        private AppManager appManager;

        private void Start()
        {
            appManager = GetComponent<AppManager>();
        }

        public void GetRemoteApps()
        {
            StartCoroutine(IGetRemoteApps());
        }

        private IEnumerator IGetRemoteApps()
        {
            using (var client = new SftpClient(ipAddress, user, password))
            {
                loadingBar.NewLoader("Retrieve App List", 1, "Connecting to device...", "Loading...");
                yield return new WaitForEndOfFrame();

                client.Connect();

                loadingBar.NewLoader("Retrieve App List", 1, "Getting app parent directories...", "Loading...");
                yield return new WaitForEndOfFrame();

                var appDirectories = ListDirectory(client, Paths.basePath);

                loadingBar.NewLoader("Retrieve App List", appDirectories.Count, "Getting app names and paths...", appDirectories[0].FullName);
                yield return new WaitForEndOfFrame();

                for (int i = 0; i < appDirectories.Count; i++)
                {
                    var appData = GetItunesMetadata(client, appDirectories[i].FullName);
                    if (appData != null)
                        remoteApps.Add(appData);

                    if (i + 1 < appDirectories.Count)
                        loadingBar.CompleteItem(appData != null ? "Retrieved " + appData.name : "Apple app, couldn't parse data...", appDirectories[i + 1].FullName);
                    else
                        loadingBar.CompleteItem(appData != null ? "Retrieved " + appData.name : "Apple app, couldn't parse data...");

                    yield return new WaitForEndOfFrame();
                }

                client.Disconnect();
            }
            appManager.SaveAppsToList(remoteApps);
        }

        string FindAppInDirectory(SftpClient client, string dir)
        {
            var directories = ListDirectory(client, dir);

            directories.Find(x => x.Name.ToLower().EndsWith(".app"));

            return directories[0].Name;
        }

        App GetItunesMetadata(SftpClient client, string dir)
        {
            System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();

            var app = new App();

            stopwatch.Start();
            var path = Path.Combine(dir, FindAppInDirectory(client, dir), "Info.plist");
            stopwatch.Stop();
            Debug.Log("FindAppInDirectory (" + dir + "): " + stopwatch.ElapsedMilliseconds);

            if (!client.Exists(path))
            {
                Debug.LogError("Failed to find file at: " + path);
                var appSplit = path.Split('/');
                var appDir = appSplit[appSplit.Length - 2];
                return new App(appDir, "", "");
                // return null;
            }

            stopwatch.Reset();
            stopwatch.Start();
            TextReader tr = client.OpenText(path);
            var strPListFile = tr.ReadToEnd();
            stopwatch.Stop();
            Debug.Log("ReadFile (" + dir + "): " + stopwatch.ElapsedMilliseconds);


            // Debug.Log(strPListFile);
            var plist = new PList();

            try
            {
                plist = new PList(strPListFile);
            }
            catch (Exception e)
            {
                Debug.Log("Failed to parse at: " + path + ", Exception: " + e);
                // var appSplit = path.Split('/');
                // var appDir = appSplit[appSplit.Length - 2];
                // return new App(appDir, "", "");
                return null;
            }

            if (plist.ContainsKey("CFBundleDisplayName"))
                app.name = plist["CFBundleDisplayName"];
            else
                app.name = plist["CFBundleName"];
            app.version = plist["CFBundleVersion"];

            return app;
        }

        private List<SftpFile> ListDirectory(SftpClient client, string dirName)
        {
            List<SftpFile> directories = new List<SftpFile>();

            if (!client.Exists(dirName))
            {
                Debug.LogError("Is your device unlocked? Path does not exist: " + dirName);
            }

            var clientAppList = client.ListDirectory(dirName);

            foreach (var entry in client.ListDirectory(dirName))
            {
                if (entry.IsDirectory && entry.Name != "." && entry.Name != "..")
                {
                    // Debug.Log(entry.FullName.Replace("/private" + Paths.basePath, ""));

                    directories.Add(entry);
                }
            }

            return directories;
        }

        // IEnumerator ListAllDirectory(SftpClient client, string dirName)
        // {
        //     if (!client.Exists(dirName))
        //     {
        //         Debug.LogError("Is your device unlocked? Path does not exist: " + dirName);
        //     }
        //     // else
        //     // {
        //     //     Debug.Log("Found directory: " + dirName);
        //     // }

        //     yield return new WaitForEndOfFrame();

        //     foreach (var entry in client.ListDirectory(dirName))
        //     {
        //         // Debug.Log(entry.Name);
        //         // Debug.Log(entry.FullName);

        //         yield return new WaitForEndOfFrame();

        //         if (entry.IsDirectory && entry.Name != "." && entry.Name != "..")
        //         {
        //             Debug.Log(entry.FullName.Replace("/private" + Paths.basePath, ""));
        //             // directories.Add(entry.Name);

        //             yield return StartCoroutine(ListAllDirectory(client, entry.FullName));
        //         }
        //         else if (entry.Name != "." && entry.Name != "..")
        //         {
        //             Debug.Log(entry.FullName.Replace("/private" + Paths.basePath, ""));

        //             directories.Add(entry.FullName);
        //         }
        //         yield return new WaitForEndOfFrame();
        //     }
        // }

        public void UploadDirectory(SftpClient client, string localPath, string remotePath)
        {
            Debug.Log(string.Format("Uploading directory {0} to {1}", localPath, remotePath));

            IEnumerable<FileSystemInfo> infos = new DirectoryInfo(localPath).EnumerateFileSystemInfos();
            foreach (FileSystemInfo info in infos)
            {
                if (info.Attributes.HasFlag(FileAttributes.Directory))
                {
                    // THIS IS DANGEROUS CODE THAT CREATES A FILE PATH
                    string subPath = remotePath + "/" + info.Name;
                    if (!client.Exists(subPath))
                    {
                        client.CreateDirectory(subPath);
                    }
                    //////////////////////////////////////////////////

                    UploadDirectory(client, info.FullName, remotePath + "/" + info.Name);
                }
                else
                {
                    using (Stream fileStream = new FileStream(info.FullName, FileMode.Open))
                    {
                        Debug.Log(string.Format("Uploading {0} ({1:N0} bytes)", info.FullName, ((FileInfo)info).Length));

                        client.UploadFile(fileStream, remotePath + "/" + info.Name);
                    }
                }
            }
        }

        private byte[] GetFile(string filePath)
        {
            MemoryStream stream = new MemoryStream();
            using (var client = new SftpClient(ipAddress, user, password))
            {
                Debug.Log("Connecting...");
                client.Connect();

                Debug.Log(filePath);

                /* if (Sftp.Exists(Paths.updatePath + filePath))
                {
                    Debug.Log("Downloading updated at " + Paths.updatePath + filePath);
                    Sftp.DownloadFile(Paths.updatePath + filePath, stream);
                }
                else */
                if (client.Exists(Paths.basePath))
                {
                    Debug.Log("Downloading original at " + Paths.basePath + filePath);
                    client.DownloadFile(Paths.basePath + filePath, stream);
                }
                else
                {
                    Debug.LogError("Is your device unlocked? Path does not exist: " + filePath);
                }

                Debug.Log("Disconnecting...");
                client.Disconnect();
            }

            return stream.ToArray();
            // return Encoding.ASCII.GetString(stream.ToArray()).Replace("\"", "").Split('\n');
        }
    }
}