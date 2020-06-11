using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

namespace SshModLoader
{
    [System.Serializable]
    public class JsonFile
    {
        public string name;
        public byte[] bytes;

        public JsonFile(string name, byte[] bytes)
        {
            this.name = name;
            this.bytes = bytes;
        }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}

