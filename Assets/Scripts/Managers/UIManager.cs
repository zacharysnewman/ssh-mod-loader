using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SshModLoader
{
    public class UIManager : MonoBehaviour
    {
        [Header("App Bar")]
        public Button deleteApp;
        public Dropdown appsDropdown;
        public Button settingsBtn;

        [Header("App Settings")]
        public GameObject appSettingsPopup;
        public InputField appSettingsNameFld;
        public InputField appSettingsPathFld;
        public InputField appSettingsUpdatePathFld;

        [Header("Menu")]
        public GameObject menuBlocker;

        // Start is called before the first frame update
        void Start()
        {
        }

        public void ClearAppSettingsPopupFields()
        {
            appSettingsNameFld.interactable = true;

            appSettingsNameFld.text = "";
            appSettingsPathFld.text = "";
            appSettingsUpdatePathFld.text = "";
        }

        public void SetAppSettingsPopupFields(App appSettings)
        {
            appSettingsNameFld.interactable = false;

            appSettingsNameFld.text = appSettings.name;
            appSettingsPathFld.text = appSettings.path;
            appSettingsUpdatePathFld.text = appSettings.updatePath;
        }

        public App GetAppSettingsFromUI()
        {
            var appSettings = new App(appSettingsNameFld.text, appSettingsPathFld.text, appSettingsUpdatePathFld.text);
            return appSettings;
        }

        public string GetAppNameFromUI()
        {
            return appsDropdown.options[appsDropdown.value].text;
        }

        public void UpdateAppsDropdownList(List<App> allAppSettings)
        {
            var appNameList = new List<Dropdown.OptionData>();
            foreach (var app in allAppSettings)
            {
                appNameList.Add(new Dropdown.OptionData(app.name));
            }

            appsDropdown.options = appNameList;
            if (appsDropdown.value >= appsDropdown.options.Count)
                appsDropdown.value = appsDropdown.options.Count - 1;

            deleteApp.interactable = appsDropdown.options.Count > 0;
            appsDropdown.interactable = appsDropdown.options.Count > 0;
            settingsBtn.interactable = appsDropdown.options.Count > 0;
            menuBlocker.SetActive(appsDropdown.options.Count == 0);
        }

        public void UpdateAppsDropdownList(List<App> allAppSettings, int newAppIndex)
        {
            UpdateAppsDropdownList(allAppSettings);

            Debug.Log(string.Format("Dropdown current: {0}, New App Index: {1}", appsDropdown.value, newAppIndex));
            appsDropdown.value = newAppIndex;
        }
    }

}
