using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JsonSave : MonoBehaviour
{
    public static JsonSave json;
    public ItemData item;
    private void Awake()
    {
        json = this;
    }
    void Start()
    {
        item.coinIncCount = 56;
        SaveManager.Save(item);
        item = SaveManager.Load();
        Debug.Log(item.coinIncCount);
    }
}
