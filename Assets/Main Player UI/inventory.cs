using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class inventory : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount == 0)
        {
            GameObject dropped = eventData.pointerDrag;
            inventory_item draggableItem = dropped.GetComponent<inventory_item>();
            draggableItem.parentAfterDrag = transform;
        }
    }
}
