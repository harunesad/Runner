using UnityEngine;
using System.IO;

public static class SaveManager
{
    public static string directory = "/SaveData/";
    public static string fileName = "SaveRunner.json";
    public static void Save(ItemData item)
    {
        string dir = Application.persistentDataPath + directory;

        if (!Directory.Exists(dir))
        {
            Directory.CreateDirectory(dir);
        }
        string json = JsonUtility.ToJson(item);
        File.WriteAllText(dir + fileName, json);
    }
    public static ItemData Load()
    {
        string fullPath = Application.persistentDataPath + directory + fileName;
        ItemData item = new ItemData();
        if (File.Exists(fullPath))
        {
            string json = File.ReadAllText(fullPath);
            item = JsonUtility.FromJson<ItemData>(json);
        }
        else
        {
            Debug.Log("Bulunamadý");
        }
        return item;
    }
}
