using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SshModLoader
{
    [System.Serializable]
    public class SshDeviceSettings
    {
        public string ipAddress;
        public string user;
        public string password;

        public SshDeviceSettings() { }
        public SshDeviceSettings(string ipAddress, string user, string password)
        {
            this.ipAddress = ipAddress;
            this.user = user;
            this.password = password;
        }

        public override string ToString()
        {
            return string.Format("IP: {0}, User: {1}, Password: {2}", ipAddress, user, password);
        }
    }
}

