using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float horizontal, vertical;
    public float speed;
    public Rigidbody2D rb;

    void Update() {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        rb.velocity = new Vector2(horizontal, vertical).normalized * speed;
    }
}
