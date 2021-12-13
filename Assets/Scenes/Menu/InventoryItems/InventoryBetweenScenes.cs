using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class InventoryBetweenScenes : MonoBehaviour
{
    public List<ItemObject> Inventory = new List<ItemObject>();
    public List<ItemObject> TowerList = new List<ItemObject>();
    public List<ItemObject> ModList = new List<ItemObject>();

    public List<string> InventoryString = new List<string>();
    public List<string> Loadstring = new List<string>();
    public List<string> TowerString = new List<string>();

    public Inventory_Save_item[] saved_inventory_items;

    public InventoryItemList ITEMLIST;
    public GameObject[] ITEMS;

    int a;
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {

       InventoryItemFinder();
        TowerChoiceFinder();
        SaveItemInInventoryString();
        SaveItemInTowerListString();
        }
        if (Input.GetKeyDown(KeyCode.L))
        {

            LoadItemString();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {

            ERASE();
        }


    }

    private void Awake()
    {
        ITEMLIST = FindObjectOfType<InventoryItemList>();
    }
    public void ERASE()
    {
        Debug.Log("ERASED");
        PlayerPrefs.DeleteKey("ItemList");
        PlayerPrefs.DeleteKey("TowerList");
    }
    public void InventoryItemFinder() // Find all items within the inventory panel
    {
        GameObject InventoryPanel;
        InventoryPanel = GameObject.Find("Inventory");
        ItemObject[] itemobject = InventoryPanel.GetComponentsInChildren<ItemObject>();

        
        foreach (ItemObject child in itemobject)
        {

            Inventory.Add(child);
        }
    }
    public void TowerChoiceFinder() // Find all towers inside the towerpanel
    {
     
        GameObject TowerPanel;
        TowerPanel = GameObject.Find("Tower");
        ItemObject[] itemobject = TowerPanel.GetComponentsInChildren<ItemObject>();
        
     
        foreach (ItemObject child in itemobject)
        {

            TowerList.Add(child);
        }
    }
    public void ModChoiceFinder() // Find all mods inside the towerpanel
    {
        Debug.Log("SAVED");
        GameObject InventoryPanel;
        ItemObject[] itemobject;
        InventoryPanel = GameObject.FindGameObjectWithTag("MainInventory");
        itemobject = FindObjectsOfType<ItemObject>();

       foreach(ItemObject child in InventoryPanel.transform)
        {
            
            Inventory.Add(child);
        }
    }
    public void SaveItemInInventoryString()
    {
        PlayerPrefs.DeleteKey("ItemList");
      


        foreach (ItemObject obj in Inventory)
        {
           
            InventoryString.Add(obj.Save());

            
        }
      
        PlayerPrefsExtra.SetList("ItemList", InventoryString);
       
    }
    public void SaveItemInTowerListString()
    {
        
        PlayerPrefs.DeleteKey("TowerList");


       
        
        foreach (ItemObject obj in TowerList)
        {

            TowerString.Add(obj.Save());


        }
        
        PlayerPrefsExtra.SetList("TowerList", TowerString);
    }
    public void LoadItemString()
    {

        TowerlistString();
        InventorylistString();
    }
    public void TowerlistString()
    {
        TowerString = PlayerPrefsExtra.GetList("TowerList", new List<string>());
        for (int i = 0; i < TowerString.Count; i++)
        {
            ITEMLIST.AddTowersFromInvList(TowerString[i]);
        }
        TowerString.Clear();
    }
    public void InventorylistString()
    {
        InventoryString = PlayerPrefsExtra.GetList("ItemList", new List<string>());

        for (int i = 0; i < InventoryString.Count; i++)
        {
            ITEMLIST.AddItemsFromInvList(InventoryString[i]);
        }

        InventoryString.Clear();
    }





    public class Inventory_Save_item
    {
        public string name;
    }
}
