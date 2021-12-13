using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TowerButton : MonoBehaviour, ISelectHandler
{
    Tile tile;
    [SerializeField] int BuildNumber;

    TowerBuilder towerBuilder;

    public Button button;
    // Start is called before the first frame update
    void Start()
    {
        towerBuilder = FindObjectOfType<TowerBuilder>();
        Button button = GetComponent<Button>();
        button.onClick.AddListener(TaskOnClick);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void TaskOnClick()
    {

    }
    public void OnSelect(BaseEventData eventData)
    {
        Debug.Log(" I DID SOMETHING!");
        towerBuilder.Build("bajs");

    }
 
}
