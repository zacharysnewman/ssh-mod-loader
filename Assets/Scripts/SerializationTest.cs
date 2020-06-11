using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SshModLoader
{
    public class SerializationTest : MonoBehaviour
    {
        public TextAsset textFile;

        public int textLength;
        public int textBytesLength;
        public int jsonFileLength;
        public int base64Length;

        // Start is called before the first frame update
        void Start()
        {
            var jsonFile = new JsonFile(textFile.name, textFile.bytes);
            textLength = textFile.text.Length;
            textBytesLength = textFile.bytes.Length;
            jsonFileLength = jsonFile.ToJson().Length;
            base64Length = PlayerPrefsSerializer.Save(jsonFile).Length;
            Debug.Log(jsonFile.ToJson());

            var directory = Path.Combine(new string[] { Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "SshModLoader", "Apps", "<AppName>", "Mods", "<ModName>" });
            var fileName = jsonFile.name;
            var fullPath = Path.Combine(directory, fileName);

            Debug.Log(fullPath);
            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);

            File.WriteAllBytes(fullPath, jsonFile.bytes);
        }

        // Update is called once per frame
        void Update()
        {

        }
    }

}
