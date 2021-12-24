using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ItemObject : MonoBehaviour
{
    
    public InventoryItem item;
    string rarityColor;

    public Image MainItemIcon;
    public Image itemIcon;
    public Image ObjectTypeIcon;
    public TextMeshProUGUI itemName;
    public TextMeshProUGUI itemCost;
    public TextMeshProUGUI ObjectType;
    public TextMeshProUGUI itemDescription;

    public TextMeshProUGUI rarity;

   

    public GameObject DescriptionWindow;
    public Image descriptionImage;

    private void Awake()
    {

       
        DescriptionWindow.SetActive(false);

        MainItemIcon.sprite = item.itemIcon;
        itemIcon.sprite = item.itemIcon;
        
        ObjectTypeIcon.sprite = item.ObjectypeIcon;
        itemName.text = item.itemName;
        itemCost.text = item.itemCost;
        ObjectType.text = item.ObjectType;
        itemDescription.text = item.itemDescription;
        rarity.text = item.rarity.ToString();
        rarityColor = item.rarity.ToString();
        Rarity();
    }
    private void OnMouseOver()
    {

        DescriptionWindow.SetActive(true);
        MainItemIcon.maskable = false;
        itemIcon.maskable = false;
        ObjectTypeIcon.maskable=false;
        itemName.maskable = false;  
        itemCost.maskable = false;
        ObjectType.maskable=false;
        itemDescription.maskable = false;
        rarity.maskable = false;    
        descriptionImage.maskable = false;
        if (Input.GetKey(KeyCode.LeftControl) && Input.GetMouseButtonDown(0))
        {
            Destroy(gameObject);
        }

    }
    private void OnMouseExit()
    {
        MainItemIcon.maskable = true;
        itemIcon.maskable = true;
        ObjectTypeIcon.maskable = true;
        itemName.maskable = true;
        itemCost.maskable = true;
        ObjectType.maskable = true;
        itemDescription.maskable = true;
        rarity.maskable = true;
        descriptionImage.maskable = true;
        DescriptionWindow.SetActive(false);
    }
    public string Save()
    {
        return item.itemName;
    }

    public void Rarity()
    {
        switch (rarityColor)
        {
            case "common" :
                ObjectTypeIcon.color = Color.grey;
                itemName.color = Color.grey;
                break;
            case "Uncommon":
                ObjectTypeIcon.color = Color.green;
                itemName.color = Color.green;
                break;
            case "Rare":
                ObjectTypeIcon.color = Color.blue;
                itemName.color = Color.blue;
                break;
            case "Epic":
                ObjectTypeIcon.color = Color.red;
                itemName.color = Color.red;
                break;
            default:
                break;
        }
    }

  
}
