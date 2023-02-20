using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacePickupItem : MonoBehaviour
{
    public Item item;
    GameObject player;
    float distance;

    void Start() {
        player = FindObjectOfType<Player>().gameObject;
    }

    void Update() {
        distance = Vector2.Distance(transform.position, player.transform.position);
    }
}
