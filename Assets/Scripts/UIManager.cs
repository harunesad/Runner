using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI startNumberText;
    int startNumber;
    void Start()
    {
        startNumber = 3;
        startNumberText.text = startNumber.ToString();
        StartCoroutine(GameStart());
    }
    void Update()
    {
        
    }
    IEnumerator GameStart()
    {
        yield return new WaitForSeconds(1);
        startNumber--;
        startNumberText.text = startNumber.ToString();
        yield return new WaitForSeconds(1);
        startNumber--;
        startNumberText.text = startNumber.ToString();
        yield return new WaitForSeconds(1);
        startNumber--;
        startNumberText.text = startNumber.ToString();
        yield return new WaitForSeconds(.1f);
        startNumberText.gameObject.SetActive(false);
        FindObjectOfType<PlayerMovement>().enabled = true;
    }
}
