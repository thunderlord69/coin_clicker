using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class coinStore_sc : MonoBehaviour
{
    public int price;
    public Sprite equipedImg;
    public Sprite unequipedImg;
    public GameObject coinObject;
    public GameObject redBtn;
    public gameManger_sc gameManagerSc;
    public TextMeshProUGUI priceText;
    public bool equiped;
    public bool purchased;
    public Image imageComponent;


    public GameObject unavaiablePanel;
    public GameObject stateTextObject;
    private bool wasActive;
    void Start()
    {
        GameObject gm = GameObject.FindWithTag("gameManager");
        gameManagerSc = gm.GetComponent<gameManger_sc>();
        priceText.text = price.ToString();

    }

    
    void Update()
    {

        //Notify if you can buy coin
        if (gameManagerSc.coins >= price && purchased == false)
        {
           redBtn.SetActive(true);
        }
        else { redBtn.SetActive(false); }
    }



    public void buySelectItemBtn()
    {
        //buy coin check
        if (gameManagerSc.coins >= price && purchased == false)
        {
            purchased = true;
            equiped = true;
            redBtn.SetActive(false);
            gameManagerSc.spendCoins(price);
            unavaiablePanel.SetActive(false);
            stateTextObject.SetActive(true);

            GameObject activeCoin = GameObject.FindWithTag("coin");
            activeCoin.SetActive(false);
            coinObject.SetActive(true);

            imageComponent.sprite = equipedImg;
            TextMeshProUGUI stateText = stateTextObject.GetComponent<TextMeshProUGUI>();
            stateText.text = "SELECTED";

            gameManagerSc.saveCoin(gameObject.name);
        }
        //select coin
        else if(equiped == false && purchased == true) 
        {
            equip();
            equiped = true;
            GameObject activeCoin = GameObject.FindWithTag("coin");
            activeCoin.SetActive(false);
            coinObject.SetActive(true);
            imageComponent.sprite = equipedImg;
            TextMeshProUGUI stateText = stateTextObject.GetComponent<TextMeshProUGUI>();
            stateText.text = "SELECTED";

        }
    }
    public void equip()
    {
        unavaiablePanel.SetActive(false);
        stateTextObject.SetActive(true);
        purchased = true;
        imageComponent.sprite = unequipedImg;
        TextMeshProUGUI stateText = stateTextObject.GetComponent<TextMeshProUGUI>();
        stateText.text = "Select";

    }
    //deselect coin
    public void deselectCoin() {
        if (equiped == true && purchased == true)
        {
            wasActive = true;
            coinObject.SetActive(false);
            equiped =false;
            imageComponent.sprite = unequipedImg;
            TextMeshProUGUI stateText = stateTextObject.GetComponent<TextMeshProUGUI>();
            stateText.text = "Select";
            StartCoroutine(checkActiveCoin());
        }
    }
    IEnumerator checkActiveCoin()
    {
        yield return new WaitForSeconds(0.00001f);

        if (wasActive==true && GameObject.FindWithTag("coin") == null)
        {
            wasActive = true;
            coinObject.SetActive(true);
            equiped = true;
            imageComponent.sprite = equipedImg;
            TextMeshProUGUI stateText = stateTextObject.GetComponent<TextMeshProUGUI>();
            stateText.text = "SELECTED";
        }
    }
}
