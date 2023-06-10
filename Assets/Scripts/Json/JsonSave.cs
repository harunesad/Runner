using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JsonSave : MonoBehaviour
{
    int save = 0;
    public static JsonSave json;
    public ItemData item;
    private void Awake()
    {
        json = this;
    }
    public void StartSave()
    {
        if (PlayerPrefs.GetInt("Save") == 0)
        {
            SaveManager.Save(item);
            save++;
            PlayerPrefs.SetInt("Save", save);
        }
        item = SaveManager.Load();
    }
    public void Save()
    {
        SaveManager.Save(item);
    }
}
