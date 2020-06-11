using System.Net;
using UnityEngine;
using Renci.SshNet;
using System.Text;
using System.IO;

namespace OldBrawlStarsModTools
{
    // EVERY VALUE (STRING AND BOOLEAN) EXCEPT NUMBERS ARE IN QUOTES
    public class RemoteFileTransfer : MonoBehaviour
    {
        [Tooltip("Your iOS WiFi IP Address")]
        public string ipAddress = "192.168.0.14";

        [Tooltip("'root' is the default value")]
        public string user = "root";

        [Tooltip("'alpine' is the default password")]
        public string password = "alpine";

        public string[] Tutorial { get { return GetFile(Paths.tutorial); } }
        // public string[] AreaEffects { get { return GetFile(Paths.areaEffects); } }
        public string[] Characters { get { return GetFile(Paths.characters); } }
        // public string[] Gadgets { get { return GetFile(Paths.gadgets); } }
        // public string[] Items { get { return GetFile(Paths.items); } }
        public string[] Locations { get { return GetFile(Paths.locations); } }
        public string[] Maps { get { return GetFile(Paths.maps); } }
        public string[] Projectiles { get { return GetFile(Paths.projectiles); } }
        public string[] Tiles { get { return GetFile(Paths.tiles); } }

        private string[] GetFile(string filePath)
        {
            MemoryStream stream = new MemoryStream();
            using (var Sftp = new SftpClient(ipAddress, user, password))
            {
                Debug.Log("Connecting...");
                Sftp.Connect();

                Debug.Log(filePath);

                if (Sftp.Exists(Paths.updatePath + filePath))
                {
                    Debug.Log("Downloading updated at " + Paths.updatePath + filePath);
                    Sftp.DownloadFile(Paths.updatePath + filePath, stream);
                }
                else if (Sftp.Exists(Paths.basePath))
                {
                    Debug.Log("Downloading original at " + Paths.updatePath + filePath);
                    Sftp.DownloadFile(Paths.basePath + filePath, stream);
                }
                else
                {
                    Debug.LogError("Is your device unlocked? File paths do not exists for update or base: " + filePath);
                }

                Debug.Log("Disconnecting...");
                Sftp.Disconnect();
            }

            var dataStr = Encoding.ASCII.GetString(stream.ToArray());
            var formattedData = dataStr.Replace("\"", "").Split('\n');

            return formattedData;
            // return Encoding.ASCII.GetString(stream.ToArray()).Replace("\"", "").Split('\n');
        }
    }
}