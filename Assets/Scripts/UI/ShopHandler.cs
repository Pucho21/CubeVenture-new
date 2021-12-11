using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopHandler : MonoBehaviour
{
    public static ShopHandler instance;
    public Transform shopContent; 
    public Sprite selectedBCG;
    public Sprite defaultBCG;
    private ShopItem selectedItem;
    public Text coinsCountText;


    [Space]
    GameObject spawnedHat;
    [SerializeField] Transform hatGOParent;


    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Web.instance.GetUserCoins(UserInfoHolder.instance.userID));
        StartCoroutine(Web.instance.GetItemsIDs(UserInfoHolder.instance.userID));
    }

    private void OnEnable()
    {
        UpdateCoinsText();
    }

    // Update is called once per frame
    //:)
    public void UpdateCoinsText()
    {
        coinsCountText.text = UserInfoHolder.instance.coins.ToString();
    }

    public void SetSelectedItem(ShopItem selected)
    {
        if (selectedItem != null)
        {
            selectedItem.SetPurchasedItem();
        }
        selectedItem = selected;
        ShowSelectedHat();
    }

    public void SetUnlockedItemsDB(List<int> itemIDs)
    {
        shopContent.GetChild(0).GetComponent<ShopItem>().SetValuesFromDB(); // ODOMKNE PRVY PRVOK V SHOPE BEZ OHLADU NA DB (v nasom pripade zakladna hat0)
        for(int i = 0; i < itemIDs.Count; i++)
        {
            shopContent.GetChild(itemIDs[i]).GetComponent<ShopItem>().SetValuesFromDB();
        }
    }

    void ShowSelectedHat()
    {
        if(spawnedHat != null)
            Destroy(spawnedHat);

        GameObject hatGO = Resources.Load<GameObject>("Hats/" + UserInfoHolder.instance.hatID);
        spawnedHat = Instantiate(hatGO, hatGOParent);
    }




}
