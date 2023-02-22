using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Item item;
    GameObject player;
    float distance;
    public RestaurantManager inventory;
    [SerializeField]
    float maxDistance;

    public AudioClip[] clips;
    public AudioSource source;

    void Start() {
        player = FindObjectOfType<Player>().gameObject;
    }

    void Pickup()
    {
        if (HoldingItem.Instance.capacity < HoldingItem.Instance.maxCapacity && inventory.itemAmounts[item.id] > 0) {
            inventory.itemAmounts[item.id] -= 1;
            HoldingItem.Instance.Add(item);
            HoldingItem.Instance.ListItems();
            source.clip = clips[0];
            source.Play();
        } else {
            source.clip = clips[1];
            source.Play();
        }
    }

    void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        if (distance < maxDistance && Input.GetKeyDown("space")) {
            Pickup();
        }
    }
}
