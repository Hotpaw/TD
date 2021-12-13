using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Manager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject T_Menu;

    bool t_menu_active = true;
    void Awake()
    {
        bool t_menu_active = true;
    }

    // Update is called once per frame
    void Update()
    {
        Tmenu();
    }

    public void Time_Scale(string a)
    {

        switch (a)
        {
            case "SpeedUp" : Time.timeScale = 2f; Debug.Log(" SpeedUp");
                break;
            case "Normal": Time.timeScale = 1f; Debug.Log(" Normal");
                break;
                    case "Paus": Time.timeScale = 0f; Debug.Log(" Paus");
                break;
            default:
                break;
        }
    }
    public void Tmenu()
    {
       
        if(t_menu_active == true && Input.GetKeyDown(KeyCode.B))
        {
        T_Menu.SetActive(false);
            t_menu_active = false;

        }
        else if(t_menu_active == false && Input.GetKeyDown(KeyCode.B))
        {
            T_Menu.SetActive(true);
            t_menu_active = true;
        }
        return;

    }
}
