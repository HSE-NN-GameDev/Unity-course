using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class FileHandler
{
    private string path;
    private string fileName;

    public FileHandler(string path, string fileName)
    {
        this.path = path;
        this.fileName = fileName;
    }

    public SaveStruct Read()
    {
        string fullPath = Path.Combine(path, fileName);
        SaveStruct save = null;

        if (File.Exists(fullPath))
        {
            try
            {
                string result;

                using (FileStream stream = new FileStream(fullPath, FileMode.Open))
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        result = reader.ReadToEnd();
                    }
                }

                save = JsonUtility.FromJson<SaveStruct>(result);
            }
            catch (Exception e)
            {
                Debug.LogError("Error on reading from " + fullPath + ": " + e);
            }

        }

        return save;

    }

    public void Write(SaveStruct saveStruct)
    {
        string fullPath = Path.Combine(path, fileName);
        try
        {
            Directory.CreateDirectory(Path.GetDirectoryName(fullPath));

            string json = JsonUtility.ToJson(saveStruct,true);

            using (FileStream stream = new FileStream(fullPath, FileMode.Create))
            {
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    writer.Write(json);
                }
            }

            Debug.Log("Save File: " + fullPath);
        }
        catch (Exception e)
        {
            Debug.LogError("Error on writing in " + fullPath + ": " + e);
        }
    }
}
