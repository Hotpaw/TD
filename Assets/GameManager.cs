using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject Tower_Bar;
    public GameObject[] Towers;
    public List<GameObject> Tower = new List<GameObject>();
    public List<string> TowerString = new List<string>();
    public List<string> InventoryString = new List<string>();

    void Start()
    {

        Debug.Log(" DEJA VU");
        SetTowers();
    }
    public void SetTowers()
    {
        LoadTowers();
        
    }
    public void Update()
    {
       

      
        
    }
    public void AddTowersToTowerBar(string i) // Add all items in the Items list to ItemsInventory.
    {

        switch (i)
        {
            case "Ballista":
                Tower.Add(Instantiate(Towers[0], Tower_Bar.transform, Tower_Bar.transform.parent.parent)); 
                break;
            case "Blocker":
                Tower.Add(Instantiate(Towers[1], Tower_Bar.transform, Tower_Bar.transform.parent.parent));
                break;
            case "DoubleDipper":
                Tower.Add(Instantiate(Towers[2], Tower_Bar.transform, Tower_Bar.transform.parent.parent));
                break;
            case "Drako":
                Tower.Add(Instantiate(Towers[3], Tower_Bar.transform, Tower_Bar.transform.parent.parent));
                break;
            case "FrostEye":
                Tower.Add(Instantiate(Towers[4], Tower_Bar.transform, Tower_Bar.transform.parent.parent));
                break;
            case "Molotov":
                Tower.Add(Instantiate(Towers[5], Tower_Bar.transform, Tower_Bar.transform.parent.parent));
                break;
            case "StingRay":
                Tower.Add(Instantiate(Towers[6], Tower_Bar.transform, Tower_Bar.transform.parent.parent));
                break;
            case "TrippleMeat":
                Tower.Add(Instantiate(Towers[7], Tower_Bar.transform, Tower_Bar.transform.parent.parent));
                break;
            case "Goran":
                Tower.Add(Instantiate(Towers[8], Tower_Bar.transform, Tower_Bar.transform.parent.parent));
                break;


        }

    }
    public void LoadTowers()
    {
        TowerString = PlayerPrefsExtra.GetList("TowerList", new List<string>());
        for (int i = 0; i < TowerString.Count; i++)
        {
            AddTowersToTowerBar(TowerString[i]);
        }
        TowerString.Clear();
    }
    public void AddLootToInventoryList(string i)
    {
        InventoryString = PlayerPrefsExtra.GetList("ItemList", new List<string>());
        InventoryString.Add(i);
        PlayerPrefsExtra.SetList("ItemList", InventoryString);

    }
    public void LootDrop()
    {
        string Loot = "";
        int i = Random.Range(0, 2);
       
     Debug.Log("Loot Roll: " + i);
      
        switch (i)
        {
            case 0: Loot = "Ballista";
                break;
            case 1:
                Loot = "Blocker";
                break;
            case 2: Debug.Log(" 2 was hit");
                break;
                default:
                break;
        }

        Debug.Log(Loot);
        AddLootToInventoryList(Loot);
    }
}
