using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class MenuUIManager : MonoBehaviour
{
    public static MenuUIManager menuUI;
    [SerializeField] List<TextMeshProUGUI> counts;
    [SerializeField] List<TextMeshProUGUI> coins;
    [SerializeField] List<Button> upgradeButtons;
    [SerializeField] List<string> textNames;
    public TextMeshProUGUI myCoin;
    [SerializeField] Button playButton, scoreboardOpenButton, scoreboardCloseButton, upgradeOpenButton, upgradeCloseButton,
                     paintingOpenButton, paintingCloseButton, button1, button2, button3, button4, button5;
    [SerializeField] GameObject scoreboardPanel, upgradepanel, paintingPanel;
    public GameObject player;
    [SerializeField] List<TextMeshProUGUI> highScoreText;
    public List<Material> playerMat;
    void Start()
    {
        myCoin.text = "" + PlayerPrefs.GetFloat("Coin");

        CharacterPaint();
        JsonSave.json.StartSave();
        for (int i = 0; i < counts.Count; i++)
        {
            counts[i].text = textNames[i] + JsonSave.json.item.counts[i];
            coins[i].text = "" + JsonSave.json.item.coins[i];
        }
        for (int i = 0; i < highScoreText.Count; i++)
        {
            highScoreText[i].text = "" + JsonSave.json.item.highScore[i].highScore;
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
        scoreboardOpenButton.onClick.AddListener(ScoreboardOpen);
        scoreboardCloseButton.onClick.AddListener(ScoreboardClose);
        upgradeOpenButton.onClick.AddListener(UpgradeOpen);
        upgradeCloseButton.onClick.AddListener(UpgradeClose);
        paintingOpenButton.onClick.AddListener(PaintingOpen);
        paintingCloseButton.onClick.AddListener(PaintingClose);

        button1.onClick.AddListener(delegate { BuyPaint(100, button1.gameObject); });
        button2.onClick.AddListener(delegate { BuyPaint(250, button2.gameObject); });
        button3.onClick.AddListener(delegate { BuyPaint(500, button3.gameObject); });
        button4.onClick.AddListener(delegate { BuyPaint(1000, button4.gameObject); });
        button5.onClick.AddListener(delegate { BuyPaint(2000, button5.gameObject); });
    }
    #region Play
    void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    #endregion
    #region CharacterPaint
    public void CharacterPaint()
    {
        for (int i = 1; i < 7; i++)
        {
            if (i == 4)
            {
                continue;
            }
            player.transform.GetChild(i).GetComponent<SkinnedMeshRenderer>().material = playerMat[PlayerPrefs.GetInt("Character")];
        }
    }
    #endregion
    #region BuyPaint
    void BuyPaint(int coin, GameObject obj)
    {
        if (PlayerPrefs.GetFloat("Coin") >= coin)
        {
            PlayerPrefs.SetFloat("Coin", PlayerPrefs.GetFloat("Coin") - coin);
            myCoin.text = "" + PlayerPrefs.GetFloat("Coin");
            PlayerPrefs.SetString(obj.transform.parent.name, "False");
            obj.SetActive(false);
            PlayerPrefs.SetString(obj.transform.parent.name + "Choose", "True");
        }
    }
    #endregion
    #region PaintingOpen
    void PaintingOpen()
    {
        paintingPanel.SetActive(true);
    }
    #endregion
    #region PaintingClose
    void PaintingClose()
    {
        CharacterPaint();
        paintingPanel.SetActive(false);
    }
    #endregion
    #region ScoreboardOpen
    void ScoreboardOpen()
    {
        scoreboardPanel.SetActive(true);
    }
    #endregion
    #region ScoreboardClose
    void ScoreboardClose()
    {
        scoreboardPanel.SetActive(false);
    }
    #endregion
    #region UpgradeOpen
    void UpgradeOpen()
    {
        upgradepanel.SetActive(true);
    }
    #endregion
    #region UpgradeClose
    void UpgradeClose()
    {
        upgradepanel.SetActive(false);
    }
    #endregion
    #region UpgradeItems
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
    #endregion
    #region UpgradeGeneral
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
    #endregion
}
