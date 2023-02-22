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
    public RestaurantManager timer;
    public SpriteRenderer counterItem;
    public Sprite[] sprites;

    public AudioSource source;
    public AudioClip[] clips;

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
                    source.clip = clips[0];
                    source.Play();
                } else if ((item.itemType == Item.ItemType.Bread && HoldingItem.Instance.Items[0].itemType == Item.ItemType.Cheese) || (item.itemType == Item.ItemType.Cheese && HoldingItem.Instance.Items[0].itemType == Item.ItemType.Bread)) {
                    item = breadCheese;
                    HoldingItem.Instance.Items.Remove(HoldingItem.Instance.Items[0]);
                    HoldingItem.Instance.ListItems();
                    source.clip = clips[0];
                    source.Play();
                } else {
                    source.clip = clips[2];
                    source.Play();
                }
            } else {
                if (item != null) {
                    Pickup();
                    item = null;
                }
            }
        }
        if (timer.currentTime <= 0) {
            item = null;
        }
        
        if (item == null) {
            counterItem.sprite = null;
        } else if (item.itemType == Item.ItemType.Bread) {
            counterItem.sprite = sprites[0];
        } else if (item.itemType == Item.ItemType.Cheese) {
            counterItem.sprite = sprites[1];
        } else if (item.itemType == Item.ItemType.Butter) {
            counterItem.sprite = sprites[2];
        } else if (item.itemType == Item.ItemType.BreadCheese) {
            counterItem.sprite = sprites[3];
        } else if (item.itemType == Item.ItemType.GrilledCheese) {
            counterItem.sprite = sprites[4];
        } else if (item.itemType == Item.ItemType.Tomato) {
            counterItem.sprite = sprites[5];
        } else if (item.itemType == Item.ItemType.TomatoSoup) {
            counterItem.sprite = sprites[6];
        }
    }

    void Pickup()
    {
        if (HoldingItem.Instance.capacity < HoldingItem.Instance.maxCapacity) {
            HoldingItem.Instance.Add(item);
            HoldingItem.Instance.ListItems();
            source.clip = clips[1];
            source.Play();
        }
    }
}
