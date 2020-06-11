using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class KvtContainer
{
    public string name;
    public List<KeyValueType> values;

    public KvtContainer(string name, List<KeyValueType> values)
    {
        this.name = name;
        this.values = values;
    }
}
