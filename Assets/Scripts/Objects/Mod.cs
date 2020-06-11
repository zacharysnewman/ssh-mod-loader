using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SshModLoader
{
    [System.Serializable]
    public class Mod
    {
        public string name = "";
        public string path = "";

        public Mod() { }
        public Mod(string name, string path)
        {
            this.name = name;
            this.path = path;
        }
    }
}

