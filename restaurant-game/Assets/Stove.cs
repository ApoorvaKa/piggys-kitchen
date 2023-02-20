using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stove : MonoBehaviour
{
    public Item item;
    [SerializeField]
    Item uncookedSandwich, grilledCheese;
    GameObject player;
    [SerializeField]
    float maxDistance, burntTime, readyTime;
    float distance, timer;
    bool canCook = false;

    void Start() {
        player = FindObjectOfType<Player>().gameObject;
    }

    void Update() {
        distance = Vector2.Distance(transform.position, player.transform.position);
        if (distance < maxDistance && Input.GetKeyDown("space")) {
            if (HoldingItem.Instance.Items.Count == 1 && (HoldingItem.Instance.Items[0].itemType == Item.ItemType.BreadCheese || HoldingItem.Instance.Items[0].itemType == Item.ItemType.Butter)) {
                if (item == null) {
                    item = HoldingItem.Instance.Items[0];
                    HoldingItem.Instance.Items.Remove(HoldingItem.Instance.Items[0]);
                    HoldingItem.Instance.ListItems();
                } else if (item.itemType != HoldingItem.Instance.Items[0].itemType) {
                    item = uncookedSandwich;
                    HoldingItem.Instance.Items.Remove(HoldingItem.Instance.Items[0]);
                    HoldingItem.Instance.ListItems();
                    canCook = true;
                }
            }
        }

        if (canCook) {
            timer += Time.deltaTime;
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 0);
        }
        if (timer >= readyTime && timer < burntTime) {
            item = grilledCheese;
            if (timer < burntTime - 5) {
                gameObject.GetComponent<SpriteRenderer>().color = new Color(0, 1, 0);
            } else {
                gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 0, 0);
            }
            if (distance < maxDistance && Input.GetKeyDown("space")) {
                Pickup();
                item = null;
                timer = 0;
                canCook = false;
                gameObject.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0);
            }
        }
        if (timer >= burntTime) {
            item = null;
            timer = 0;
            canCook = false;
            gameObject.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0);
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
