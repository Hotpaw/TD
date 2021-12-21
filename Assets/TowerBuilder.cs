using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TowerBuilder : MonoBehaviour
{
    Tile tile;
    [SerializeField]string BuildNumber;
    public static Tower towerPrefab;
    [SerializeField] List<Tower> towerList = new List<Tower>();
  

   
    // Start is called before the first frame update
    void Start()
    {
        tile = FindObjectOfType<Tile>();
       
      
    }

    // Update is called once per frame
    void Update()
    {
        BuildKey();
    }

    
    public void Build(string a)
    {
     
        switch (a)
        {
            case "Ballista":
                towerPrefab = towerList[0];
                break;
            case "TrippleMeat":
                towerPrefab = towerList[1];
                break;
            case "Blocker":
                towerPrefab = towerList[2];
                break;
            case "DoubleDipper":
                towerPrefab = towerList[3];
                break;
            case "Goran":
                towerPrefab = towerList[4];
                break;
            case "FrostEye":
                towerPrefab = towerList[5];
                break;
            case "Molotov":
                towerPrefab = towerList[6];
                break;
            case "StingRay":
                towerPrefab = towerList[7];
                break;
            case "Drako":
                towerPrefab = towerList[8];
                break;
            case "Cryo1":
                towerPrefab = towerList[9];
                break;
            default:
                break;
        }

    }

    void BuildKey()
    {
      
       
        
    }
}
