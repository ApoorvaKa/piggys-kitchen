using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Item item;

    void Pickup()
    {
        if (HoldingItem.Instance.capacity < HoldingItem.Instance.maxCapacity) {
            HoldingItem.Instance.Add(item);
            HoldingItem.Instance.ListItems();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player") {
            Pickup();
        }
    }
}
