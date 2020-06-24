using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SshModLoader
{
    public class Local
    {
        public readonly string path = Application.persistentDataPath;
        public readonly string apps = Path.Combine(Application.persistentDataPath, "Apps");

        public string GetAppBackup(string appName)
        {
            return Path.Combine(apps, appName, "AppBackup");
        }

        public string GetPrefsBackup(string appName)
        {
            return Path.Combine(apps, appName, "PrefsBackup");
        }

        public string GetAppMods(string appName)
        {
            return Path.Combine(apps, appName, "Mods");
        }

        public string GetAppMod(string appName, string modName)
        {
            return Path.Combine(GetAppMods(appName), modName);
        }
    }
}
