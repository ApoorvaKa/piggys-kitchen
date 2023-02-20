using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float horizontal, vertical;
    public float speed;
    public Rigidbody2D rb;
    public bool canMove = true;

    void Update() {
        if (canMove) {
            horizontal = Input.GetAxisRaw("Horizontal");
            vertical = Input.GetAxisRaw("Vertical");
            rb.velocity = new Vector2(horizontal, vertical).normalized * speed;
        } else {
            rb.velocity = new Vector2(0, 0);
        }
    }
}
