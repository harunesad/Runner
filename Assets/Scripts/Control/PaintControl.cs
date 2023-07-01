using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class PaintControl : MonoBehaviour, IPointerDownHandler
{
    private void Start()
    {
        if (transform.childCount == 0)
        {
            PlayerPrefs.SetString(transform.name + "Choose", "True");
            PlayerPrefs.SetInt("Character", Convert.ToInt32(gameObject.name));
        }
        if (transform.childCount > 0 && PlayerPrefs.GetString(gameObject.name) == "True")
        {
            transform.GetChild(0).gameObject.SetActive(true);
        }
        else if (transform.childCount > 0 && PlayerPrefs.GetString(gameObject.name) == "False")
        {
            transform.GetChild(0).gameObject.SetActive(false);
        }
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        if (PlayerPrefs.GetString(transform.name + "Choose") == "True")
        {
            PlayerPrefs.SetInt("Character", Convert.ToInt32(gameObject.name));
            Debug.Log(PlayerPrefs.GetInt("Character"));
        }
    }
}
