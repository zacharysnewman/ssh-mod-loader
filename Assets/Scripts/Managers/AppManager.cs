using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using UnityEngine;

namespace SshModLoader
{
    public class AppManager : MonoBehaviour
    {
        private UIManager uiManager;
        public List<App> apps = new List<App>();

        // Start is called before the first frame update
        void Start()
        {
            LoadAppsFromPlayerPrefs();

            uiManager = GetComponent<UIManager>();
            uiManager.UpdateAppsDropdownList(apps);
        }

        public void SaveAppsToList(List<App> appList)
        {
            foreach (var app in appList)
            {
                var appIndexInList = apps.FindIndex(x => x.name == app.name);

                if (appIndexInList >= 0)
                {
                    apps[appIndexInList] = app;
                }
                else
                {
                    apps.Add(app);
                }
            }

            apps = apps.OrderBy(x => x.name).ToList();

            uiManager.UpdateAppsDropdownList(apps);
        }

        private void SaveAppsToPlayerPrefs()
        {
            var json = JsonConvert.SerializeObject(apps);
            PlayerPrefs.SetString("Apps", json);
        }

        private void LoadAppsFromPlayerPrefs()
        {
            var savedAppsJson = PlayerPrefs.GetString("Apps");
            if (savedAppsJson != "")
            {
                var loadedApps = JsonConvert.DeserializeObject<List<App>>(savedAppsJson);
                foreach (var app in loadedApps)
                {
                    app.loadedFromPrefs = true;
                }
                apps = loadedApps;
            }
        }

        private void OnApplicationQuit()
        {
            SaveAppsToPlayerPrefs();
        }
    }
}
