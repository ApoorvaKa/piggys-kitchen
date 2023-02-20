using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Counter : MonoBehaviour
{
    public Item item;
    [SerializeField]
    Item breadCheese;
    GameObject player;
    [SerializeField]
    float maxDistance;
    float distance;

    void Start() {
        player = FindObjectOfType<Player>().gameObject;
    }

    void Update() {
        distance = Vector2.Distance(transform.position, player.transform.position);
        if (distance < maxDistance && Input.GetKeyDown("space")) {
            if (HoldingItem.Instance.Items.Count == 1) {
                if (item == null) {
                    item = HoldingItem.Instance.Items[0];
                    HoldingItem.Instance.Items.Remove(HoldingItem.Instance.Items[0]);
                    HoldingItem.Instance.ListItems();
                } else if ((item.itemType == Item.ItemType.Bread && HoldingItem.Instance.Items[0].itemType == Item.ItemType.Cheese) || (item.itemType == Item.ItemType.Cheese && HoldingItem.Instance.Items[0].itemType == Item.ItemType.Bread)) {
                    item = breadCheese;
                    HoldingItem.Instance.Items.Remove(HoldingItem.Instance.Items[0]);
                    HoldingItem.Instance.ListItems();
                }
            } else {
                if (item != null) {
                    Pickup();
                    item = null;
                }
            }
        }
    }

    void Pickup()
    {
        if (HoldingItem.Instance.capacity < HoldingItem.Instance.maxCapacity) {
            HoldingItem.Instance.Add(item);
            HoldingItem.Instance.ListItems();
        }
    }
}
