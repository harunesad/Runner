using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuUIManager : MonoBehaviour
{
    [SerializeField] List<TextMeshProUGUI> counts;
    [SerializeField] List<TextMeshProUGUI> coins;
    [SerializeField] List<Button> upgradeButtons;
    [SerializeField] List<string> textNames;
    [SerializeField] TextMeshProUGUI myCoin;
    [SerializeField] Button playButton;
    void Start()
    {
        PlayerPrefs.SetFloat("Coin", 100000);
        myCoin.text = "" + PlayerPrefs.GetFloat("Coin");

        JsonSave.json.StartSave();
        for (int i = 0; i < counts.Count; i++)
        {
            counts[i].text = textNames[i] + JsonSave.json.item.counts[i];
            coins[i].text = "" + JsonSave.json.item.coins[i];
        }

        upgradeButtons[0].onClick.AddListener(UpgradeCoinIncCount);
        upgradeButtons[1].onClick.AddListener(UpgradeHealthInc);
        upgradeButtons[2].onClick.AddListener(UpgradeHealthReduce);
        upgradeButtons[3].onClick.AddListener(UpgradeScoreMultiplyStartCount);
        upgradeButtons[4].onClick.AddListener(UpgradeScoreMultiplyInc);
        upgradeButtons[5].onClick.AddListener(UpgradeScoreMultiplyIncTime);
        upgradeButtons[6].onClick.AddListener(UpgradeShieldStartCount);
        upgradeButtons[7].onClick.AddListener(UpgradeSpeedStartCount);
        upgradeButtons[8].onClick.AddListener(UpgradeSpeedSlowTime);
        playButton.onClick.AddListener(PlayGame);
    }
    void UpgradeCoinIncCount()
    {
        Upgrade(JsonSave.json.item.counts, 0, JsonSave.json.item.coins, .1f, counts, coins, textNames);
    }
    void UpgradeHealthInc()
    {
        Upgrade(JsonSave.json.item.counts, 1, JsonSave.json.item.coins, 1, counts, coins, textNames);
    }
    void UpgradeHealthReduce()
    {
        Upgrade(JsonSave.json.item.counts, 2, JsonSave.json.item.coins, -1, counts, coins, textNames);
    }
    void UpgradeScoreMultiplyStartCount()
    {
        Upgrade(JsonSave.json.item.counts, 3, JsonSave.json.item.coins, 1, counts, coins, textNames);
    }
    void UpgradeScoreMultiplyInc()
    {
        Upgrade(JsonSave.json.item.counts, 4, JsonSave.json.item.coins, .1f, counts, coins, textNames);
    }
    void UpgradeScoreMultiplyIncTime()
    {
        Upgrade(JsonSave.json.item.counts, 5, JsonSave.json.item.coins, .1f, counts, coins, textNames);
    }
    void UpgradeShieldStartCount()
    {
        Upgrade(JsonSave.json.item.counts, 6, JsonSave.json.item.coins, 1, counts, coins, textNames);
    }
    void UpgradeSpeedStartCount()
    {
        Upgrade(JsonSave.json.item.counts, 7, JsonSave.json.item.coins, 1, counts, coins, textNames);
    }
    void UpgradeSpeedSlowTime()
    {
        Upgrade(JsonSave.json.item.counts, 8, JsonSave.json.item.coins, 1f, counts, coins, textNames);
    }
    void Upgrade(List<float> item, int index, List<int> itemCoin, float itemInc, List<TextMeshProUGUI> itemText, List<TextMeshProUGUI> itemCoinText, List<string> itemName)
    {
        if (PlayerPrefs.GetFloat("Coin") >= itemCoin[index])
        {
            PlayerPrefs.SetFloat("Coin", PlayerPrefs.GetFloat("Coin") - itemCoin[index]);
            itemCoin[index] += itemCoin[index];
            itemCoinText[index].text = "" + itemCoin[index];
            item[index] += itemInc;
            itemText[index].text = itemName[index] + item[index];
            myCoin.text = "" + PlayerPrefs.GetFloat("Coin");
            for (int i = 0; i < JsonSave.json.item.counts.Count; i++)
            {
                if (i == index)
                {
                    JsonSave.json.item.counts[i] = item[i];
                    JsonSave.json.item.coins[i] = itemCoin[i];
                }
            }
            SaveManager.Save(JsonSave.json.item);
            JsonSave.json.item = SaveManager.Load();
        }
    }
    void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
