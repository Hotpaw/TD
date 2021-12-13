using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class Tile : MonoBehaviour
{

    [SerializeField] Tower towerPrefab;
    [SerializeField] List<Tower> towerList = new List<Tower>();
    [SerializeField] bool isPlaceable;
    public int buildNumber = 0;
   
    public bool IsPlaceable { get { return isPlaceable; } }

    GridManager gridManager;
    Pathfinder pathfinder;

    public Vector2Int coordinates = new Vector2Int();
 

    public bool GetIsPlaceable() { return isPlaceable; }

    private void Awake()
    {

        gridManager = FindObjectOfType<GridManager>();
        pathfinder = FindObjectOfType<Pathfinder>();
        towerPrefab = FindObjectOfType<Tower>();
    }
    private void Start()
    {

        if (gridManager != null)
        {
            coordinates = gridManager.GetCoordinatesFromPosition(transform.position);

            if (!isPlaceable)
            {
                gridManager.BlockNode(coordinates);
            }
        }
    }


    private void OnMouseDown()
    {
      
        towerPrefab = TowerBuilder.towerPrefab;
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (gridManager.Getnode(coordinates).isWalkable && !pathfinder.WillBlockPath(coordinates))
        {

            {
                bool isSuccessfull = towerPrefab.CreateTower(towerPrefab, transform.position);
                if (isSuccessfull)
                {

                    gridManager.BlockNode(coordinates);
                    pathfinder.NotifyReceivers();
                }


            }


        }
    }
    private void OnMouseOver()
    {
     
    }
    private void OnMouseExit()
    {
       
    }
}

   
  
    
   

