using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SshModLoader
{
    public class IPValidator : MonoBehaviour
    {
        private InputField ipAddressFld;
        private string prevValue;

        // Start is called before the first frame update
        void Awake()
        {
            ipAddressFld = GetComponent<InputField>();
        }

        public void OnValueChanged(string newValue)
        {
            if (ContainsOtherCharacters(newValue))
            {
                ipAddressFld.text = prevValue;
            }

            prevValue = ipAddressFld.text;
        }

        private bool ContainsOtherCharacters(string val)
        {
            foreach (var c in val)
            {
                if (!(char.IsNumber(c) || c == '.'))
                    return true;
            }

            return false;
        }
    }
}


