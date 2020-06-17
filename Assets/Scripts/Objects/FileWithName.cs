using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

namespace SshModLoader
{
    [System.Serializable]
    public class FileWithName
    {
        public string name;
        public byte[] bytes;

        public FileWithName(string name, byte[] bytes)
        {
            this.name = name;
            this.bytes = bytes;
        }
    }
}

