using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    void Start() {
        player = FindObjectOfType<Player>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        if (distance < maxDistance && Input.GetKeyDown("space")) {
            if (HoldingItem.Instance.Items[0].itemType == Item.ItemType.GrilledCheese) {
                money.increaseMoney(Random.Range(lowGain[tipLevel.TipsLevelNum],highGain[tipLevel.TipsLevelNum]));
                HoldingItem.Instance.Items.Remove(HoldingItem.Instance.Items[0]);
                HoldingItem.Instance.ListItems();
                source.clip = clips[0];
                source.Play();
            } else if (HoldingItem.Instance.Items[0].itemType == Item.ItemType.TomatoSoup) {
                money.increaseMoney(Random.Range(lowGain[tipLevel.TipsLevelNum],highGain[tipLevel.TipsLevelNum]));
                HoldingItem.Instance.Items.Remove(HoldingItem.Instance.Items[0]);
                HoldingItem.Instance.ListItems();
                source.clip = clips[0];
                source.Play();
            } else {
                source.clip = clips[1];
                source.Play();
            }
        }
    }
}
