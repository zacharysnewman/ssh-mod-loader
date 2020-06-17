﻿////////////////////////////////////////////////////////////////////////////////////
/// Found here:
/// https://forum.unity.com/threads/c-serialization-playerprefs-mystery.72156/
////////////////////////////////////////////////////////////////////////////////////

using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace SshModLoader
{
    public static class PlayerPrefsSerializer
    {
        public static string Save(object serializableObject)
        {
            MemoryStream memoryStream = new MemoryStream();
            bf.Serialize(memoryStream, serializableObject);
            string tmp = System.Convert.ToBase64String(memoryStream.ToArray());
            return tmp;
        }

        public static BinaryFormatter bf = new BinaryFormatter();
        // serializableObject is any struct or class marked with [Serializable]
        public static void Save(string prefKey, object serializableObject)
        {
            MemoryStream memoryStream = new MemoryStream();
            bf.Serialize(memoryStream, serializableObject);
            string tmp = System.Convert.ToBase64String(memoryStream.ToArray());
            PlayerPrefs.SetString(prefKey, tmp);
        }

        public static object Load<T>(string prefKey)
        {
            if (!PlayerPrefs.HasKey(prefKey))
                return default(T);

            string serializedData = PlayerPrefs.GetString(prefKey);
            MemoryStream dataStream = new MemoryStream(System.Convert.FromBase64String(serializedData));

            T deserializedObject = (T)bf.Deserialize(dataStream);

            return deserializedObject;
        }

    }
}

