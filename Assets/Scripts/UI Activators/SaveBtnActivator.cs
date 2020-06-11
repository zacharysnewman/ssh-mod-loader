using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SshModLoader
{
    public class SaveBtnActivator : MonoBehaviour
    {
        public InputField appNameFld;
        public InputField appPathFld;
        public InputField appUpdatePathFld;

        private Button saveBtn;

        // Start is called before the first frame update
        void Start()
        {
            saveBtn = GetComponent<Button>();
        }

        // Update is called once per frame
        void Update()
        {
            bool canSave = !(IsNullEmptyOrWhitespace(appNameFld.text) || IsNullEmptyOrWhitespace(appPathFld.text));
            saveBtn.interactable = canSave;
        }

        private bool IsNullEmptyOrWhitespace(string str)
        {
            return string.IsNullOrEmpty(str) || string.IsNullOrWhiteSpace(str);
        }
    }
}
