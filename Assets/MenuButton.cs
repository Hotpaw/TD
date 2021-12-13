using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MenuButton : MonoBehaviour
{
	public Button yourButton;
	public int Level;
	public string LinkName;
	DropZone DZ;
    InventoryBetweenScenes INVB;

	public GameObject menuWindow;
	bool menuOpen = false;
	void Start()
	{
        INVB = FindObjectOfType<InventoryBetweenScenes>();
		DZ = FindObjectOfType<DropZone>();
		Button btn = yourButton.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
	}

	void TaskOnClick()
	{
		Menu_Choice(Level, LinkName);
	}

	void Menu_Choice(int a, string b)
    {
		a = Level;
        switch(a){
			case 1:
				SceneManager.LoadScene("Level1");
				break;
			case 2: Application.Quit();
				break;
			case 3:
				SceneManager.LoadScene("Menu");
				break;
			case 4:if(menuOpen == false) menuWindow.SetActive(true); Level = 5; menuOpen = true;
				break;
			case 5:
				if (menuOpen == true) menuWindow.SetActive(false); Level = 4; menuOpen = false;
				break;
			case 6: AddtoGameInventory(); Debug.Log(" TEST PRESSD ");
				break;
			default:
				break;
        }
    }


    //public void AddToTowerAndMod()
    //{
    //    GameObject TDINV;
    //    GameObject MDINV;
    //    TDINV = GameObject.FindGameObjectWithTag("TowerInventory");
    //    MDINV = GameObject.FindGameObjectWithTag("ModInventory");


    //    if (TDINV.name == ("Tower"))
    //    {
    //        Debug.Log(" TOWER INVENTORY");
    //        foreach (Transform obj in TDINV.transform)
    //        {
    //            if (obj.tag == ("Item"))
    //            {

    //                INVB.Inventory.Add(obj.gameObject);
    //            }

    //        }
    //    }
    //    if (MDINV.name == ("Mod"))
    //    {
    //        Debug.Log(" MOD INVENTORY");
    //        foreach (Transform obj in MDINV.transform)
    //        {
    //            if (obj.tag == ("Item"))
    //            {

    //                INVB.Inventory.Add(obj.gameObject);
    //            }

    //        }
    //    }

    //}
    public void AddtoGameInventory() // Add items in Tower and Mod to Inbetweenscenes inventory.
    {
        GameObject INV;
        ItemObject[] itemobject;
        INV = GameObject.FindGameObjectWithTag("MainInventory");
        itemobject = FindObjectsOfType<ItemObject>();

        foreach(ItemObject script in itemobject)
        {

        INVB.Inventory.Add(script);
        }
        INVB.SaveItemInInventoryString();

        //if (INV.name == ("Inventory"))
        //{
        //    Debug.Log(" TOWER INVENTORY");
        //    foreach (GameObject obj in INV.transform)
        //    {
        //        if (obj.tag == ("Item"))
        //        {
        //            itemobject = GetComponent<ItemObject>();
        //            INVB.Inventory.Add(obj.gameObject);
        //        }

        //    }
        //}
      
    }
    //public void EmptyGameInventory() // Remove items in Tower and Mod to Inbetweenscenes inventory.
    //{
    //    GameObject TDINV;
    //    GameObject MDINV;
    //    TDINV = GameObject.FindGameObjectWithTag("TowerInventory");
    //    MDINV = GameObject.FindGameObjectWithTag("ModInventory");

    //    if (TDINV.name == ("Tower"))
    //    {

    //        foreach (Transform obj in this.transform)
    //        {
    //            if (obj.tag == ("Item"))
    //            {

    //                INVB.Inventory.Remove(obj.gameObject);
    //            }

    //        }
    //    }
    //    if (MDINV.name == ("Mod"))
    //    {

    //        foreach (Transform obj in this.transform)
    //        {
    //            if (obj.tag == ("Item"))
    //            {

    //                INVB.Inventory.Remove(obj.gameObject);
    //            }

    //        }
    //    }
    //}
}
