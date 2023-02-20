using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Video Link: https://www.youtube.com/watch?v=AoD_F1fSFFg
public class ItemController : MonoBehaviour
{
    public Item item;

    public void RemoveItem()
    {
        HoldingItem.Instance.Remove(item);

        Destroy(gameObject);
    }

    public void AddItem(Item newItem)
    {
        item = newItem;
    }

    public void UseItem()
    {
        if (!item) {
            Debug.Log("Item does not exist");
        }
        else {
            Debug.Log("Using item...");
        }
        switch(item.itemType)
        {
            
        }

        RemoveItem();
    }
}