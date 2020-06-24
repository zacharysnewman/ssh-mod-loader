using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
            // Debug.Log(Application.persistentDataPath);
            LoadApps();

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

        private void SaveApps()
        {
            Prefs.SaveAppSettings(apps);
        }

        private void LoadApps()
        {
            apps = Prefs.LoadAppSettings();
        }

        private void OnApplicationQuit()
        {
            SaveApps();
        }
    }
}
