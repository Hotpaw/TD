using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject Tower_Bar;
    public GameObject LootPoint;
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

        if (Input.GetKeyDown(KeyCode.L))
        {

            LootDrop();
        }


    }
    public void AddTowersToTowerBar(string i) // Add all items in the Items list to towerbar.
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
            case "Cryo-1":
                Tower.Add(Instantiate(Towers[9], Tower_Bar.transform, Tower_Bar.transform.parent.parent));
                break;


        }

    }
    public void LoadTowers() // Load each tower in the TowerChoice menu and instantiates them in thetowerbar for use.
    {
        TowerString = PlayerPrefsExtra.GetList("TowerList", new List<string>());
        for (int i = 0; i < TowerString.Count; i++)
        {
            AddTowersToTowerBar(TowerString[i]);
        }
        TowerString.Clear();
    }
    public void AddLootToInventoryList(string i) // returns the saved inventory list then adds anyfound items to it and saves it again.
    {
        InventoryString = PlayerPrefsExtra.GetList("ItemList", new List<string>());
        InventoryString.Add(i);
        PlayerPrefsExtra.SetList("ItemList", InventoryString);

    }
    public void LootDrop() // rolls a random integer between 0 and X then sends a string to Addloottoinventory and adds to invent list
    {
        string Loot = "";
        int i = Random.Range(0, 11);
       
     Debug.Log("Loot Roll: " + i);
      
        switch (i)
        {
            case 0: 
                Loot = "Ballista";
                break;
            case 1:
                Loot = "Blocker";
                break;
            case 2:
                Loot = "Blocker";
                break;
            case 3:
                Loot = "DoubleDipper";
                break;
            case 4:
                Loot = "Drako";
                break;
            case 5:
                Loot = "FrostEye";
                break;
            case 6:
                Loot = "Molotov";
                break;
            case 7:
                Loot = "StingRay";
                break;
            case 8:
                Loot = "TrippleMeat";
                break;
            case 9:
                Loot = "Goran";
                break;
            case 10:
                Loot = "Cryo-1";
                break;


            default:
                break;
        }

        switch (Loot) // Displays the loot found ingame.
        {
            case "Ballista":
                Tower.Add(Instantiate(Towers[0], LootPoint.transform, LootPoint.transform.parent.parent));
                break;
            case "Blocker":
                Tower.Add(Instantiate(Towers[1], LootPoint.transform, LootPoint.transform.parent.parent));
                break;
            case "DoubleDipper":
                Tower.Add(Instantiate(Towers[2], LootPoint.transform, LootPoint.transform.parent.parent));
                break;
            case "Drako":
                Tower.Add(Instantiate(Towers[3], LootPoint.transform, LootPoint.transform.parent.parent));
                break;
            case "FrostEye":
                Tower.Add(Instantiate(Towers[4], LootPoint.transform, LootPoint.transform.parent.parent));
                break;
            case "Molotov":
                Tower.Add(Instantiate(Towers[5], LootPoint.transform, LootPoint.transform.parent.parent));
                break;
            case "StingRay":
                Tower.Add(Instantiate(Towers[6], LootPoint.transform, LootPoint.transform.parent.parent));
                break;
            case "TrippleMeat":
                Tower.Add(Instantiate(Towers[7], LootPoint.transform, LootPoint.transform.parent.parent));
                break;
            case "Goran":
                Tower.Add(Instantiate(Towers[8], LootPoint.transform, LootPoint.transform.parent.parent));
                break;
            case "Cryo-1":
                Tower.Add(Instantiate(Towers[9], LootPoint.transform, LootPoint.transform.parent.parent));
                break;


        }
        AddLootToInventoryList(Loot);
        LootDisperser LootDisplay = FindObjectOfType<LootDisperser>();
        LootDisplay.StartLootDisperser();
    }
}
