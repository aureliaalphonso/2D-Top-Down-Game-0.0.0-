using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class inventory_item : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [HideInInspector] public items item;
    [Header("UI")]
    public Image image;

    [HideInInspector] public Transform parentAfterDrag;

    public void InitializeItem(items newitems)
    {
        item = newitems;
        image.sprite = newitems.image;
    }
    //drag and drop
    public void OnBeginDrag(PointerEventData eventData) 
    {
        image.raycastTarget = false;
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        image.raycastTarget = true;
        transform.SetParent(parentAfterDrag);
    }
}