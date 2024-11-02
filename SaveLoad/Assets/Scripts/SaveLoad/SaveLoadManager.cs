using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SaveLoadManager : MonoBehaviour
{
    [SerializeField]
    string fileName;

    public static SaveLoadManager instance { get; private set; }

    private SaveStruct saveStruct = new SaveStruct();
    private List<ISaveLoad> saveLoads;
    private FileHandler fh;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        fh = new FileHandler(Application.persistentDataPath, fileName);
        saveLoads = new List<ISaveLoad>(FindObjectsOfType<MonoBehaviour>().OfType<ISaveLoad>());
    }

    public void NewGame()
    {
        saveStruct = new SaveStruct();
    }

    public void SaveGame()
    {
        foreach (ISaveLoad slObj in saveLoads)
        {
            slObj.Save(saveStruct);
        }

        fh.Write(saveStruct);
    }

    public void LoadGame()
    {
        saveStruct = fh.Read();

        if(saveStruct == null)
        {
            NewGame();
        }

        foreach (ISaveLoad slObj in saveLoads)
        {
            slObj.Load(saveStruct);
        }
    }
}
