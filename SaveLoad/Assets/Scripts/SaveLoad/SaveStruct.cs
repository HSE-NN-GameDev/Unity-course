using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveStruct
{
    public Vector2 pos = Vector2.zero;
    public SerialDictionary<string, bool> toggles = new SerialDictionary<string, bool>();

}
