using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SubmitDish : MonoBehaviour
{
    GameObject player;
    public TestMoney money;
    [SerializeField]
    float maxDistance;
    [SerializeField]
    int[] lowGain, highGain;
    public ResourceManager tipLevel;
    float distance;

    public AudioClip[] clips;
    public AudioSource source;

    bool soundNotPlayed = true;
    int fib1 = 1, fib2 = 1;
    int grilledCheeseOrders, tomatoSoupOrders, gCCount = 0, tSCount = 0;
    public TextMeshProUGUI gcText, tsText;
    public RestaurantManager roundManager;

    void Start() {
        player = FindObjectOfType<Player>().gameObject;
        grilledCheeseOrders = Random.Range(0,2);
        tomatoSoupOrders = 1-grilledCheeseOrders;
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        if (distance < maxDistance && Input.GetKeyDown("space")) {
            if (HoldingItem.Instance.Items[0].itemType == Item.ItemType.GrilledCheese && gCCount < grilledCheeseOrders) {
                money.increaseMoney(Random.Range(lowGain[tipLevel.TipsLevelNum],highGain[tipLevel.TipsLevelNum]));
                HoldingItem.Instance.Items.Remove(HoldingItem.Instance.Items[0]);
                HoldingItem.Instance.ListItems();
                gCCount += 1;
                source.clip = clips[0];
                source.Play();
            } else if (HoldingItem.Instance.Items[0].itemType == Item.ItemType.TomatoSoup && tSCount < tomatoSoupOrders) {
                money.increaseMoney(Random.Range(lowGain[tipLevel.TipsLevelNum],highGain[tipLevel.TipsLevelNum]));
                HoldingItem.Instance.Items.Remove(HoldingItem.Instance.Items[0]);
                HoldingItem.Instance.ListItems();
                tSCount += 1;
                source.clip = clips[0];
                source.Play();
            } else {
                source.clip = clips[1];
                source.Play();
            }
        }

        gcText.text = gCCount.ToString() + "/" + grilledCheeseOrders.ToString();
        tsText.text = tSCount.ToString() + "/" + tomatoSoupOrders.ToString();

        if (gCCount == grilledCheeseOrders && tSCount == tomatoSoupOrders && soundNotPlayed) {
            roundManager.money += roundManager.round * 10;
            roundManager.currentTime = 0;
            source.clip = clips[2];
            source.Play();
            soundNotPlayed = false;
        }
    }

    public void Randomize(int round) {
        if (round % 2 == 0) {
            fib1 += fib2;
            grilledCheeseOrders = Random.Range(0,fib1+1);
            tomatoSoupOrders = fib1-grilledCheeseOrders;
        } else {
            fib2 += fib1;
            grilledCheeseOrders = Random.Range(0,fib2+1);
            tomatoSoupOrders = fib2-grilledCheeseOrders;
        }
        gCCount = 0;
        tSCount = 0;
        soundNotPlayed = true;
    }
}
