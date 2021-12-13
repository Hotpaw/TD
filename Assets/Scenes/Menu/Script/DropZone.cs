using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DropZone : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{

    public List<GameObject> list;

    public Draggable.Slot typeOfItem = Draggable.Slot.TOWER;
  
    
 

    InventoryBetweenScenes InvBS;

    public void OnDrop(PointerEventData eventData)
    {
        Draggable d = eventData.pointerDrag.GetComponent<Draggable>();

        

        if (d != null)
        {
            if(typeOfItem == d.typeOfItem || typeOfItem== Draggable.Slot.INVENTORY)
            d.parentToReturnTo = this.transform;
          
        }
      
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
       
    }

    public void OnPointerExit(PointerEventData eventData)
    {
     
    }

    // Start is called before the first frame update
    
    void Start()
    {
    
       
    }

    // Update is called once per frame
 

}
