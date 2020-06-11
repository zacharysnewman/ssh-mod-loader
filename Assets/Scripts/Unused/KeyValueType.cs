using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class KeyValueType
{
    public string Key = "";
    public string Value = "";
    public string Type = "";

    public KeyValueType(string key, string value, string type)
    {
        this.Key = key;
        this.Value = value;
        this.Type = type;
    }
}
