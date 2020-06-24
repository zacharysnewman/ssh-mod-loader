using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

namespace SshModLoader
{
    public static class Prefs
    {
        private static string appsKey = "Apps";
        private static string sshSettingsKey = "SshDeviceSettings";

        public static void SaveAppSettings(List<App> apps)
        {
            var json = JsonConvert.SerializeObject(apps);
            PlayerPrefs.SetString(appsKey, json);
        }

        public static List<App> LoadAppSettings()
        {
            List<App> apps = new List<App>();

            var savedAppsJson = PlayerPrefs.GetString(appsKey);
            if (savedAppsJson != "")
            {
                var loadedApps = JsonConvert.DeserializeObject<List<App>>(savedAppsJson);
                foreach (var app in loadedApps)
                {
                    app.loadedFromPrefs = true;
                }
                apps = loadedApps;
            }

            return apps;
        }

        public static void SaveSshDeviceSettings(SshDeviceSettings settings)
        {
            var json = JsonConvert.SerializeObject(settings);
            PlayerPrefs.SetString(sshSettingsKey, json);
            Debug.Log(json);
        }

        public static SshDeviceSettings LoadSshDeviceSettings()
        {
            SshDeviceSettings settings = new SshDeviceSettings();

            var json = PlayerPrefs.GetString(sshSettingsKey);

            if (json != "")
            {
                settings = JsonConvert.DeserializeObject<SshDeviceSettings>(json);
            }

            return settings;
        }
    }
}
