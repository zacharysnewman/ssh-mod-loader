using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SshModLoader
{
    public class SshSettingsPopup : MonoBehaviour
    {
        public InputField ipAddressFld;
        public InputField userFld;
        public InputField passwordFld;

        public SshDeviceSettings sshDeviceSettings = new SshDeviceSettings();

        // Start is called before the first frame update
        void Start()
        {
            sshDeviceSettings = Prefs.LoadSshDeviceSettings();
            UpdateFieldsFromSettings();
        }

        private void UpdateFieldsFromSettings()
        {
            ipAddressFld.text = sshDeviceSettings.ipAddress;
            userFld.text = sshDeviceSettings.user;
            passwordFld.text = sshDeviceSettings.password;
        }

        public void OnIpChanged(string newIp)
        {
            sshDeviceSettings.ipAddress = newIp;
        }

        public void OnUserChanged(string newUser)
        {
            sshDeviceSettings.user = newUser;
        }

        public void OnPasswordChanged(string newPassword)
        {
            sshDeviceSettings.password = newPassword;
        }

        public void SaveBtn()
        {
            Prefs.SaveSshDeviceSettings(sshDeviceSettings);
        }
    }
}

