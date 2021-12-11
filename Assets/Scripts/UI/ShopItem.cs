using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour
{
    private string itemID;
    public int price;
    private bool isPurchased;

    private void Awake()
    {
        itemID = "hat" + transform.GetSiblingIndex();
    }

    // Start is called before the first frame update
    void Start()
    {
        transform.GetChild(0).GetComponent<Text>().text = price.ToString();
    }

    public void SetValuesFromDB()
    {
        if (itemID.Equals(UserInfoHolder.instance.hatID))
        {
            SetSelected();
            Debug.Log("on enable nastavujem selectnuty item");
        }
        else SetPurchasedItem();
    }

    public void SetSelected()
    {
        transform.GetChild(0).gameObject.SetActive(false);
        //transform.GetComponent<Image>().sprite = ShopHandler.instance.selectedBCG;
        transform.GetComponent<Image>().color = new Color32(140, 250, 70, 255);
        isPurchased = true;
        UserInfoHolder.instance.SetHatID(itemID);
        ShopHandler.instance.SetSelectedItem(this); 
        //Debug.Log("selected " + itemID);

    }

    public void SetPurchasedItem()
    {
        transform.GetChild(0).gameObject.SetActive(false);
        transform.GetComponent<Image>().color = Color.white;
        //transform.GetComponent<Image>().sprite = ShopHandler.instance.defaultBCG;
        isPurchased = true;
        //Debug.Log("kupeny itemID " + itemID);

    }

    public void ShopItemClicked()
    {
        if(isPurchased)
        {
            SetSelected();
        } else
        {
            //podmienka na penaze (dotaz na DB) a potom setselected
            if(UserInfoHolder.instance.coins >= price) //nemame love
            {
                SetSelected();
                UserInfoHolder.instance.CoinsUpdateDB(price);
                StartCoroutine(Web.instance.BuyItem(transform.GetSiblingIndex().ToString()));
                ShopHandler.instance.UpdateCoinsText();
            } else
            {
                Debug.Log("Not enough coins warning!!!!!!!!");
            }
        }
    }

}
