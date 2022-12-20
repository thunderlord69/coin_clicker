using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class item_sc : MonoBehaviour
{
    public int price;
    public Sprite equipedImg;
    public GameObject itemOnDashboard;
    public GameObject redBtn;
    public gameManger_sc gameManagerSc;
    public TextMeshProUGUI priceText;
    public bool equiped;
    public Image imageComponent;
    public GameObject unEquipedPanel;
    public GameObject equipedPanel;
    void Start()
    {
        GameObject gm = GameObject.FindWithTag("gameManager");
        gameManagerSc = gm.GetComponent<gameManger_sc>();
        priceText.text = price.ToString();
    }
    void Update()
    {
        //Check if is object already on field
        if (itemOnDashboard.active)
        {
            equip();
        }

        //Notify if you can buy item
        if (gameManagerSc.coins >= price && equiped==false)
        {redBtn.SetActive(true);
        }else { redBtn.SetActive(false); }
    }
    public void equip() {
        equiped = true;

        unEquipedPanel.SetActive(false);
        redBtn.SetActive(false);
        equipedPanel.SetActive(true);
        itemOnDashboard.SetActive(true);
        imageComponent.sprite = equipedImg;
    }
    public void purchaseItemBtn() {

        if (gameManagerSc.coins >= price)
        {
            gameManagerSc.spendCoins(price);
            equip();
            gameManagerSc.saveItem(itemOnDashboard);
        }
    }
}
