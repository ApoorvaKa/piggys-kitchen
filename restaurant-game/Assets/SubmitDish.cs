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
    int lowGain, highGain;
    float distance;

    void Start() {
        player = FindObjectOfType<Player>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        if (distance < maxDistance && Input.GetKeyDown("space") && HoldingItem.Instance.Items[0].itemType == Item.ItemType.GrilledCheese) {
            money.increaseMoney(Random.Range(lowGain,highGain));
            HoldingItem.Instance.Items.Remove(HoldingItem.Instance.Items[0]);
            HoldingItem.Instance.ListItems();
        }
    }
}
