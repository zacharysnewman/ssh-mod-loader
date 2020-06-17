using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SshModLoader
{
    public class UIManager : MonoBehaviour
    {
        [Header("App Bar")]
        public Dropdown appsDropdown;

        [Header("Menu")]
        public GameObject menuBlocker;

        // Start is called before the first frame update
        void Start()
        {
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
                appsDropdown.value = 0;

            appsDropdown.interactable = appsDropdown.options.Count > 0;
            menuBlocker.SetActive(appsDropdown.options.Count == 0);
        }
    }

}
