using System.Collections;
using System.Collections.Generic;
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

        // Update is called once per frame
        void Update()
        {

        }

        public void DeleteCurrentApp()
        {
            var appName = uiManager.GetAppNameFromUI();
            apps.RemoveAll(x => x.name == appName);
            uiManager.UpdateAppsDropdownList(apps);
        }

        public void EditApp()
        {
            var appName = uiManager.GetAppNameFromUI();

            var appSettings = apps.Find(x => x.name == appName);

            if (appSettings != null)
                uiManager.SetAppSettingsPopupFields(appSettings);
        }

        public void SaveCurrentAppToList()
        {
            var app = uiManager.GetAppSettingsFromUI();
            var appIndexInList = apps.FindIndex(x => x.name == app.name);

            if (appIndexInList >= 0)
            {
                apps[appIndexInList] = app;
            }
            else
            {
                apps.Add(app);
            }

            uiManager.UpdateAppsDropdownList(apps, apps.Count - 1);
        }

        private void SaveAppsToPlayerPrefs()
        {
            var json = JsonConvert.SerializeObject(apps);
            PlayerPrefs.SetString("Apps", json);
        }

        private void LoadAppsFromPlayerPrefs()
        {
            var savedApps = PlayerPrefs.GetString("Apps");
            if (savedApps != "")
            {
                apps = JsonConvert.DeserializeObject<List<App>>(savedApps);
            }
        }

        private void OnApplicationQuit()
        {
            SaveAppsToPlayerPrefs();
        }
    }
}
