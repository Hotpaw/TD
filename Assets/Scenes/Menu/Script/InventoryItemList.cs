using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InventoryItemList : MonoBehaviour
{
    public List<GameObject> ItemsInInventory = new List<GameObject>(5);
    public GameObject InvMenuPanel;
    public GameObject TowMenuPanel;
    public GameObject ModMenuPanel;
    public GameObject[] Items;

    public int FirstTimePlaying = 1;
    public int PlayBool;
 
    

    private void Awake()
    {
      
    }

    private void Start()
    {
       

    }

    public void PopulateFirstPlayer()
    {
        PlayBool = PlayerPrefs.GetInt("FirstTimePlaying");
        if (PlayBool == 0)
        {
            PlayBool = 1;
            PlayerPrefs.SetInt("FirstTimePlaying", PlayBool);
        }
        Debug.Log(" Play Bool: " + PlayBool);
        FirstTimePlaying = PlayerPrefs.GetInt("FirstTimePlaying");
        Debug.Log(" FirstTime: " + FirstTimePlaying); ;

        if (FirstTimePlaying == 1)
        {
            AddItemsFromInvList("Ballista");
            AddItemsFromInvList("Blocker");
            AddItemsFromInvList("Goran");
            PlayBool = 2;
            FirstTimePlaying = PlayBool;
            PlayerPrefs.SetInt("FirstTimePlaying", PlayBool);
            Debug.Log(" CODE RUN");

        }
    }

    public void AddItemsFromInvList(string i) // Add all items in the Items list to ItemsInventory.
    {
      
        switch (i)
        {
            case "Ballista": ItemsInInventory.Add(Instantiate(Items[0], InvMenuPanel.transform, InvMenuPanel.transform.parent.parent.parent));
                break;
            case "Blocker":
                ItemsInInventory.Add(Instantiate(Items[1], InvMenuPanel.transform, InvMenuPanel.transform.parent.parent.parent));
                break;
            case "DoubleDipper":
                ItemsInInventory.Add(Instantiate(Items[2], InvMenuPanel.transform, InvMenuPanel.transform.parent.parent.parent));
                break;
            case "Drako":
                ItemsInInventory.Add(Instantiate(Items[3], InvMenuPanel.transform, InvMenuPanel.transform.parent.parent.parent));
                break;
            case "FrostEye":
                ItemsInInventory.Add(Instantiate(Items[4], InvMenuPanel.transform, InvMenuPanel.transform.parent.parent.parent));
                break;
            case "Molotov":
                ItemsInInventory.Add(Instantiate(Items[5], InvMenuPanel.transform, InvMenuPanel.transform.parent.parent.parent));
                break;
            case "StingRay":
                ItemsInInventory.Add(Instantiate(Items[6], InvMenuPanel.transform, InvMenuPanel.transform.parent.parent.parent));
                break;
            case "TrippleMeat":
                ItemsInInventory.Add(Instantiate(Items[7], InvMenuPanel.transform, InvMenuPanel.transform.parent.parent.parent));
                break;
            case "Goran":
                ItemsInInventory.Add(Instantiate(Items[8], InvMenuPanel.transform, InvMenuPanel.transform.parent.parent.parent));
                break;


        }

            //ItemsInInventory.Add(Instantiate(Items[i], InvMenuPanel.transform, InvMenuPanel.transform.parent.parent)); // Create items in Itemlist and store them inside the inventory slot.
 
        
      
   
    }
    public void AddTowersFromInvList(string i) // Add all items in the Items list to ItemsInventory.
    {

        switch (i)
        {
            case "Ballista":
                ItemsInInventory.Add(Instantiate(Items[0], TowMenuPanel.transform, InvMenuPanel.transform.parent.parent.parent));
                break;
            case "Blocker":
                ItemsInInventory.Add(Instantiate(Items[1], TowMenuPanel.transform, InvMenuPanel.transform.parent.parent.parent));
                break;
            case "DoubleDipper":
                ItemsInInventory.Add(Instantiate(Items[2], TowMenuPanel.transform, InvMenuPanel.transform.parent.parent.parent));
                break;
            case "Drako":
                ItemsInInventory.Add(Instantiate(Items[3], TowMenuPanel.transform, InvMenuPanel.transform.parent.parent.parent));
                break;
            case "FrostEye":
                ItemsInInventory.Add(Instantiate(Items[4], TowMenuPanel.transform, InvMenuPanel.transform.parent.parent.parent));
                break;
            case "Molotov":
                ItemsInInventory.Add(Instantiate(Items[5], TowMenuPanel.transform, InvMenuPanel.transform.parent.parent.parent));
                break;
            case "StingRay":
                ItemsInInventory.Add(Instantiate(Items[6], TowMenuPanel.transform, InvMenuPanel.transform.parent.parent.parent));
                break;
            case "TrippleMeat":
                ItemsInInventory.Add(Instantiate(Items[7], TowMenuPanel.transform, InvMenuPanel.transform.parent.parent.parent));
                break;
            case "Goran":
                ItemsInInventory.Add(Instantiate(Items[8], TowMenuPanel.transform, InvMenuPanel.transform.parent.parent.parent));
                break;


        }

        //ItemsInInventory.Add(Instantiate(Items[i], InvMenuPanel.transform, InvMenuPanel.transform.parent.parent)); // Create items in Itemlist and store them inside the inventory slot.




    }

}
