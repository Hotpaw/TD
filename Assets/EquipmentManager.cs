using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{

    #region Singleton
    public static EquipmentManager instance;

    private void Awake()
    {
        instance = this;
    }
    #endregion

    InventoryItem[] currentEquipment;

    void Start()
    {
        int numslots = System.Enum.GetNames(typeof(InventoryItem)).Length;
        currentEquipment = new InventoryItem[numslots];
    }
    public void Equip(InventoryItem newItem)
    {
        int slotindex = (int)newItem.Type;

        currentEquipment[slotindex] = newItem;
    }
}
