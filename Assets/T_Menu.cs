using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class T_Menu : MonoBehaviour
{
    string name;
    private bool ClickUI;
    // Start is called before the first frame update

    private void Awake()
    {
        name = gameObject.name;
    }
    private void OnMouseUp()
    {
        ClickUI = false;
        if (EventSystem.current.IsPointerOverGameObject())
        {
            if (EventSystem.current.currentSelectedGameObject.name == "TowerMenu")
            {
                ClickUI = true;
            }
        }

        if (ClickUI)
        {
            Debug.Log("Click UI button");
        }
    }
} 
