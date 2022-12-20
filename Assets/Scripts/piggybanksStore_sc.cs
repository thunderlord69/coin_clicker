using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class piggybanksStore_sc : MonoBehaviour
{
    public int price;
    public Sprite equipedImg;
    public Sprite unEquipedImg;
    public Image imageComponent;
    public GameObject redBtn;
    public GameObject itemOnDashboard;

    public bool enablePurchase;
    public bool equiped;
    public GameObject conditionObject;
    public gameManger_sc gameManagerSc;

    public GameObject pricePanel;
    public GameObject conditionPanel;
    public GameObject equipedPanel;
    public TextMeshProUGUI priceText;
    void Start()
    {
        GameObject gm = GameObject.FindWithTag("gameManager");
        gameManagerSc = gm.GetComponent<gameManger_sc>();
        priceText.text = price.ToString();
    }

    // Update is called once per frame
    void Update()
    {

        //Check if is object already on field
        if (itemOnDashboard.active)
        {
            equip();
        }


        if (conditionObject.active==true && equiped == false)
        {
            EnablePurchase();
        }
        if(gameManagerSc.coins >= price && enablePurchase == true && equiped == false)
        {
            redBtn.SetActive(true);
        }
        else
        {
            redBtn.SetActive(false);
        }
        
    }

    public void EnablePurchase() {
        enablePurchase = true;
        pricePanel.SetActive(true);
        conditionPanel.SetActive(false);
        imageComponent.sprite = unEquipedImg;
    }

    public void Purchase()
    {
        if (gameManagerSc.coins >= price && enablePurchase == true)
        {
            equip();
            gameManagerSc.saveItem(itemOnDashboard);
        }
    }
    public void equip()
    {
        equiped = true;
        itemOnDashboard.SetActive(true);
        redBtn.SetActive(false);
        pricePanel.SetActive(false);
        conditionPanel.SetActive(false);
        equipedPanel.SetActive(true);
        imageComponent.sprite = equipedImg;
    }

}
