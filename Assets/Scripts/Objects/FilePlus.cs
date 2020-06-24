using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SshModLoader
{
    public class FilePlus
    {
        public string name = "";
        public string path = "";
        public byte[] bytes = new byte[0];

        public FilePlus() { }
        public FilePlus(string name, string path, byte[] bytes)
        {
            this.name = name;
            this.path = path;
            this.bytes = bytes;
        }
    }
}

