using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class gameManger_sc : MonoBehaviour
{
    public TextMeshProUGUI coinsText;
    public GameObject storePanel;

    public GameObject itemStoreBtn;
    public GameObject piggyStoreBtn;
    public GameObject coinsStoreBtn;

    public GameObject itemStorePanel;
    public GameObject piggyStorePanel;
    public GameObject coinStorePanel;

    public GameObject debugStorePanel;
    public bool enablePlay = true;
    public int coins;
    bool sound = true;

    
    public Text Text;
    public AudioListener audioListener;

    public GameObject[] items;
    public int itemsNum;

    public GameObject[] coinsPurchased;
    public int coinsNum;
    void Start()
    {
        //load items
        if (!PlayerPrefs.HasKey("itemsNum"))
        {
            PlayerPrefs.SetInt("itemsNum", 0);
        }
        else
        {
            itemsNum = PlayerPrefs.GetInt("itemsNum");
            
            for (int i = 0; i <= itemsNum; i++)
                {
                foreach (GameObject item in items)
                {
                    if (item.name == PlayerPrefs.GetString(i.ToString()))
                    {
                        item.SetActive(true);

                    }
                }
            }
        }
        //load coins
        if (!PlayerPrefs.HasKey("coinsNum"))
        {
            PlayerPrefs.SetInt("coinsNum", 0);
        }
        else
        {
            coinsNum = PlayerPrefs.GetInt("coinsNum");

            for (int i = 0; i <= coinsNum; i++)
            {
                
                foreach (GameObject coinItem in coinsPurchased)
                {
                    if (coinItem.name == PlayerPrefs.GetString("c"+i.ToString()) )
                    {
                        Debug.Log("ALOO");
                        coinStore_sc p = coinItem.GetComponent<coinStore_sc>();
                        p.equip();
                    }
                    
                }
            }
        }

        if (!PlayerPrefs.HasKey("coins"))
        {
            PlayerPrefs.SetInt("coins", 0);
            coins = 0;
        }
        else {
            coins = PlayerPrefs.GetInt("coins");
        }
        coinsText.text = coins.ToString();
    }

    
    void Update()
    {
        
    }
    public void addCoins(int coinNum)
    {
        coins = coins + coinNum;
        coinsText.text = coins.ToString();
        PlayerPrefs.SetInt("coins", coins);
    }
    public void spendCoins(int coinNum)
    {
        coins = coins - coinNum;
        coinsText.text = coins.ToString();
        PlayerPrefs.SetInt("coins", coins);
    }

    public void storePanelActive(){

        if (storePanel.active)
        {
            enablePlay = true;
            storePanel.SetActive(false);
        }
        else {
            enablePlay = false;
            storePanel.SetActive(true); 
        }
        
    }
    public void itemStoreActive()
    {
        itemStorePanel.SetActive(true);
        var textMeshPro = itemStoreBtn.GetComponent<TextMeshProUGUI>();
        textMeshPro.color = new Color(1, 1, 1, 1);

        textMeshPro = piggyStoreBtn.GetComponent<TextMeshProUGUI>();
        textMeshPro.color = new Color(1, 1, 1, .5f);
        piggyStorePanel.SetActive(false);
        textMeshPro = coinsStoreBtn.GetComponent<TextMeshProUGUI>();
        textMeshPro.color = new Color(1, 1, 1, .5f);
        coinStorePanel.SetActive(false);
    }
    public void piggybankStoreActive()
    {
        piggyStorePanel.SetActive(true);
        var textMeshPro = piggyStoreBtn.GetComponent<TextMeshProUGUI>();
        textMeshPro.color = new Color(1, 1, 1, 1);

        textMeshPro = itemStoreBtn.GetComponent<TextMeshProUGUI>();
        textMeshPro.color = new Color(1, 1, 1, .5f);
        itemStorePanel.SetActive(false);
        textMeshPro = coinsStoreBtn.GetComponent<TextMeshProUGUI>();
        textMeshPro.color = new Color(1, 1, 1, .5f);
        coinStorePanel.SetActive(false);
    }
    public void coinsStoreActive()
    {
        coinStorePanel.SetActive(true);
        var textMeshPro = coinsStoreBtn.GetComponent<TextMeshProUGUI>();
        textMeshPro.color = new Color(1, 1, 1, 1);

        textMeshPro = itemStoreBtn.GetComponent<TextMeshProUGUI>();
        textMeshPro.color = new Color(1, 1, 1, .5f);
        itemStorePanel.SetActive(false);
        textMeshPro = piggyStoreBtn.GetComponent<TextMeshProUGUI>();
        textMeshPro.color = new Color(1, 1, 1, .5f);
        piggyStorePanel.SetActive(false);
    }

    public void saveItem(GameObject saveObject)
    {
        itemsNum++;
        PlayerPrefs.SetString(itemsNum.ToString(), saveObject.name);
        PlayerPrefs.SetInt("itemsNum", itemsNum);
    }

    public void saveCoin(string saveObject)
    {
        coinsNum++;
        PlayerPrefs.SetString("c"+coinsNum.ToString(), saveObject);
        PlayerPrefs.SetInt("coinsNum", coinsNum);
        
    }
    public void debugStoreActive()
    {
        if (debugStorePanel.active)
        {
            debugStorePanel.SetActive(false);
            enablePlay = true;
        }
        else
        {
            debugStorePanel.SetActive(true);
            enablePlay = false;
        }
        

    }
    public void addDebugCoins()
    {
        coins = coins + 10000;
        coinsText.text = coins.ToString();
        PlayerPrefs.SetInt("coins", coins);
    }
    public void volumeOnOf()
    {
        if (sound == true)
        {
            AudioListener.volume = 0f;
            Text.text = "SOUND OFF";
            sound = false;
        }
        else
        {
            AudioListener.volume = 1f;
            Text.text = "SOUND ON";
            sound = true;
        }
        
    }
    public void resetGame()
    {
        coins = 0;
        coinsText.text = coins.ToString();

        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("SampleScene");
    }
}

