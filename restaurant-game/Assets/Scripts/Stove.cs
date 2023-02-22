using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stove : MonoBehaviour
{
    public Item item;
    [SerializeField]
    Item uncookedSandwich, grilledCheese, tomato, tomatoSoup;
    GameObject player;
    public ResourceManager stoveLevel;
    public RestaurantManager roundTime;
    public Sprite[] sprites;
    [SerializeField]
    float maxDistance, burntTime, readyTime;
    float distance, timer;
    bool isCooking = false;

    public AudioSource source;
    public AudioClip[] clips;

    void Start() {
        player = FindObjectOfType<Player>().gameObject;
    }

    void Update() {
        distance = Vector2.Distance(transform.position, player.transform.position);
        if (distance < maxDistance && Input.GetKeyDown("space") && isCooking == false) {
            if (HoldingItem.Instance.Items[0].itemType == Item.ItemType.BreadCheese || HoldingItem.Instance.Items[0].itemType == Item.ItemType.Butter) {
                if (item == null) {
                    item = HoldingItem.Instance.Items[0];
                    HoldingItem.Instance.Items.Remove(HoldingItem.Instance.Items[0]);
                    HoldingItem.Instance.ListItems();
                    gameObject.GetComponent<SpriteRenderer>().sprite = sprites[1];
                    source.clip = clips[0];
                    source.Play();
                } else if (item.itemType != HoldingItem.Instance.Items[0].itemType) {
                    item = uncookedSandwich;
                    HoldingItem.Instance.Items.Remove(HoldingItem.Instance.Items[0]);
                    HoldingItem.Instance.ListItems();
                    isCooking = true;
                    source.clip = clips[1];
                    source.Play();
                }
            } else if (HoldingItem.Instance.Items[0].itemType == Item.ItemType.Tomato && item == null) {
                item = tomato;
                HoldingItem.Instance.Items.Remove(HoldingItem.Instance.Items[0]);
                HoldingItem.Instance.ListItems();
                isCooking = true;
                gameObject.GetComponent<SpriteRenderer>().sprite = sprites[2];
                source.clip = clips[2];
                source.Play();
            } else {
                source.clip = clips[5];
                source.Play();
            }
        }

        if (isCooking) {
            timer += Time.deltaTime;
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 0);
        }
        if (timer >= (readyTime - stoveLevel.StoveLevelNum * 2) && timer < burntTime) {
            source.PlayOneShot(clips[4]);
            if (item.itemType == Item.ItemType.Tomato) {
                item = tomatoSoup;
            }
            if (item.itemType == Item.ItemType.RawSandwich) {
                item = grilledCheese;
            }
            if (timer < burntTime - 5) {
                gameObject.GetComponent<SpriteRenderer>().color = new Color(0, 1, 0);
            } else {
                gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 0, 0);
            }
            if (distance < maxDistance && Input.GetKeyDown("space")) {
                Pickup();
                item = null;
                timer = 0;
                isCooking = false;
                gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1);
                gameObject.GetComponent<SpriteRenderer>().sprite = sprites[0];
                source.clip = clips[3];
                source.Play();
            }
        }
        if (timer >= burntTime || roundTime.currentTime <= 0) {
            item = null;
            timer = 0;
            source.PlayOneShot(clips[5]);
            isCooking = false;
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1);
            gameObject.GetComponent<SpriteRenderer>().sprite = sprites[0];
            source.Stop();
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
