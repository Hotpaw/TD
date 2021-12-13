using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

[System.Serializable]
[CreateAssetMenu(fileName = "InventoryItem", menuName = "ScriptableObjects/Tower_Bar")]
public class Scriptable_Tower_Bar : ScriptableObject
{

    public enum Rarity { Common, Uncommon, Rare, Epic };
    public enum itemType { TOWER, MOD };
    public itemType Type = itemType.TOWER;
    public Rarity rarity = Rarity.Common;



    public Sprite itemIcon;
    public Sprite ObjectypeIcon;
    public string itemName;
    public string itemCost;
    public string ObjectType;
    public string itemDescription;
   


}

