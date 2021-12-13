using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Time_Button : MonoBehaviour
{
    public Button button;
    Game_Manager gameManager;
    string name;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<Game_Manager>();
        name = gameObject.name;
        button.onClick.AddListener(TaskOnClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void TaskOnClick()
    {
        gameManager.Time_Scale(name);
        Debug.Log(name + " Was clicked.");
    }
}
