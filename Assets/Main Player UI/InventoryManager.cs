using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public inventory[] inventorySlots;
    public GameObject inventoryItemPrefab;

    public void AddItem(items item)
    {

        for (int i = 0; i < inventorySlots.Length; i++)
        {
            inventory slot = inventorySlots[i];
            inventory_item itemInSlot = slot.GetComponentInChildren<inventory_item>();
            if(itemInSlot == null)
            {
                SpawnNewItem(item, slot);
                return;
            }
        }
    }

    void SpawnNewItem(items item, inventory slot)
    {
        GameObject newItemGo = Instantiate(inventoryItemPrefab, slot.transform);
        inventory_item inventoryItem = newItemGo.GetComponent<inventory_item>();
        inventoryItem.InitializeItem(item);
    }
}
