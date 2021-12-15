using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvOnEnable : MonoBehaviour
{
    InventoryItemList ItemList;
    InventoryBetweenScenes INBS;
    int i;

    private void OnEnable()
    {

        if(i == 0)
        {
            
        ItemList = FindObjectOfType<InventoryItemList>();
        INBS = FindObjectOfType<InventoryBetweenScenes>();
        ItemList.PopulateFirstPlayer();
        INBS.LoadAll();
            i = 1;
        }
           INBS.InventoryString.Clear();
            INBS.TowerString.Clear();
        INBS.Inventory.Clear();
        INBS.TowerList.Clear();
  
    }
}
