using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleScript : MonoBehaviour, ISaveLoad
{
    Toggle tog;
    [SerializeField]
    public string id;

    [ContextMenu("Generate Id")]
    public void GenerateId()
    {
        id = System.Guid.NewGuid().ToString();
    }

    private void Start()
    {
        tog = GetComponent<Toggle>();   
    }

    public void Save(SaveStruct saveStruct)
    {
        if (saveStruct.toggles.ContainsKey(id))
        {
            saveStruct.toggles.Remove(id);
        }

        saveStruct.toggles.Add(id, tog.isOn);
    }

    public void Load(SaveStruct saveStruct)
    {
        bool on;
        if (saveStruct.toggles.TryGetValue(id, out on))
        {
            tog.isOn = on;
        }  
    }
}
