using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public static class SaveManager
{
    public static string directory = "/SaveData/";
    public static string fileName = "SaveProduct.json";
    public static void Save(ItemData item)
    {
        string dir = Application.persistentDataPath + directory;

        if (!Directory.Exists(dir))
        {
            Directory.CreateDirectory(dir);
        }
        string json = JsonUtility.ToJson(item);
        File.WriteAllText(dir + fileName, json);
        Debug.Log(dir);
    }
    public static ItemData Load()
    {
        string fullPath = Application.persistentDataPath + directory + fileName;
        ItemData so = new ItemData();

        if (File.Exists(fullPath))
        {
            string json = File.ReadAllText(fullPath);
            so = JsonUtility.FromJson<ItemData>(json);
        }
        else
        {
            Debug.Log("sadas");
        }
        return so;
    }
}
