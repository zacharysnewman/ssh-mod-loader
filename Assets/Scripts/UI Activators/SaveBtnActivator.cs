using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SshModLoader
{
    public class SaveBtnActivator : MonoBehaviour
    {
        public InputField[] requiredFields;
        private Button saveBtn;

        // Start is called before the first frame update
        void Start()
        {
            saveBtn = GetComponent<Button>();
        }

        // Update is called once per frame
        void Update()
        {
            bool canSave = true;
            foreach (var fld in requiredFields)
            {
                if (IsNullEmptyOrWhitespace(fld.text))
                {
                    canSave = false;
                    break;
                }
            }

            saveBtn.interactable = canSave;
        }

        private bool IsNullEmptyOrWhitespace(string str)
        {
            return string.IsNullOrEmpty(str) || string.IsNullOrWhiteSpace(str);
        }
    }
}
