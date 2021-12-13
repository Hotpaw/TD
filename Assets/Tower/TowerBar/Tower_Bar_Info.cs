using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;


public class Tower_Bar_Info : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
{

    public Scriptable_Tower_Bar item;

    TowerBuilder TB;

    public Image MainItemIcon;
    public Image itemIcon;
    public Image ObjectTypeIcon;
    public TextMeshProUGUI itemName;
    public TextMeshProUGUI itemCost;
    public TextMeshProUGUI ObjectType;
    public TextMeshProUGUI itemDescription;
    

    public TextMeshProUGUI rarity;



    public GameObject DescriptionWindow;

    private void Awake()
    {
        TB = FindObjectOfType<TowerBuilder>();
        DescriptionWindow.SetActive(false);

        MainItemIcon.sprite = item.itemIcon;
        itemIcon.sprite = item.itemIcon;
        ObjectTypeIcon.sprite = item.ObjectypeIcon;
        itemName.text = item.itemName;
        itemCost.text = item.itemCost;
        ObjectType.text = item.ObjectType;
        itemDescription.text = item.itemDescription;
        rarity.text = item.rarity.ToString();


    }
    void OnMouseDown()
    {
        TB.Build(item.name);
    }
   
    public void OnPointerEnter(PointerEventData eventData)
    {
        
        DescriptionWindow.SetActive(true);
    }
    private void OnMouseExit()
    {
        DescriptionWindow.SetActive(false);
    }
    public string Save()
    {
        return item.itemName;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        DescriptionWindow.SetActive(false);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        TB.Build(item.name);
    }
}

