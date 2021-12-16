using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootDisperser : MonoBehaviour
{
   
    public void StartLootDisperser()
    {
        StartCoroutine("LootCycle");
    }

    public IEnumerator LootCycle()
    {

        yield return new WaitForSeconds(5);

        ItemObject itemobject;
        
        itemobject = FindObjectOfType<ItemObject>();

        foreach (Transform child in this.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
    }
}
