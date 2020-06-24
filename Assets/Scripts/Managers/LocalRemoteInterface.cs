using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SshModLoader
{

    public class LocalRemoteInterface : MonoBehaviour
    {
        private SshManager sshManager;

        // Start is called before the first frame update
        IEnumerator Start()
        {
            sshManager = GetComponent<SshManager>();
            using (var client = new Renci.SshNet.SftpClient("192.168.0.11", "root", "alpine"))
            {
                client.Connect();

                Debug.Log("Connected.");
                yield return StartCoroutine(sshManager.GetAllFilePaths(client, "/private/var/mobile/Containers/Data/Application/D7BD557F-D731-4D5B-88C2-325B46CA1F97"));
                client.Disconnect();
            }
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void SaveAppBackup()
        {
            // Get remote files from SSH

            // Save local files to disk
        }

        public void SavePrefsBackup()
        {

        }
    }
}