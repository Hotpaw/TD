using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    
{
    public enum Slot { TOWER, MOD, INVENTORY};
    public Slot typeOfItem = Slot.TOWER;

   public Transform parentToReturnTo = null;

    GameObject placeHolder = null;
    int number;

    Camera m_cam;
    void Start()
    {
        if (Camera.main.GetComponent<PhysicsRaycaster>() == null)
            Debug.Log("Camera doesn't ahve a physics raycaster.");

        m_cam = Camera.main;
    }
  public void OnBeginDrag(PointerEventData eventData)
    {
        placeHolder = new GameObject();
        placeHolder.transform.SetParent(this.transform.parent);


        placeHolder.transform.SetSiblingIndex(this.transform.GetSiblingIndex());

        parentToReturnTo = this.transform.parent;
        this.transform.SetParent(this.transform.parent.parent);

        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Ray R = m_cam.ScreenPointToRay(Input.mousePosition); // Get the ray from mouse position
        Vector3 PO = transform.position; // Take current position of this draggable object as Plane's Origin
        Vector3 PN = -m_cam.transform.forward; // Take current negative camera's forward as Plane's Normal
        float t = Vector3.Dot(PO - R.origin, PN) / Vector3.Dot(R.direction, PN); // plane vs. line intersection in algebric form. It find t as distance from the camera of the new point in the ray's direction.
        Vector3 P = R.origin + R.direction * t; // Find the new point.

        transform.position = P;

      
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        

        GameObject TowerPanel;
        GameObject InventoryPanel;
      
       
        TowerPanel = GameObject.Find("Tower");
        InventoryPanel = GameObject.Find("Inventory");
        ItemObject[] itemobject = TowerPanel.GetComponentsInChildren<ItemObject>();
      
       
         
            
      
    
        

            foreach(ItemObject obj in itemobject)
            {
            number = itemobject.Length;

              
            
            }
        if (number >= 6)
        {
            this.transform.SetParent(InventoryPanel.transform);
            Debug.Log(" RETURN ME");
        }
        else
        {
               this.transform.SetParent(parentToReturnTo);
        }

        Debug.Log(number);
        

    
        
        
        
        GetComponent<CanvasGroup>().blocksRaycasts = true;
        
        Destroy(placeHolder);
    }
}
