using System.Security.Cryptography.X509Certificates;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SshModLoader
{
    [System.Serializable]
    public class App
    {
        public string name = "";
        public string path = "";
        public string updatePath = "";

        public List<Mod> mods = new List<Mod>();

        public App() { }
        public App(string name, string path, string updatePath)
        {
            this.name = name;
            this.path = path;
            this.updatePath = updatePath;
        }

        public void RemoveMod(string modName)
        {
            mods.RemoveAll(x => x.name == modName);

            // TODO: Delete local mod files
        }

        public void AddMod(Mod mod)
        {
            var modIndex = mods.FindIndex(x => x.name == mod.name);

            if (modIndex < 0)
            {
                mods.Add(mod);
            }
            else
            {
                mods[modIndex] = mod;
            }

            // TODO: Copy mod files to local
        }
    }

}
