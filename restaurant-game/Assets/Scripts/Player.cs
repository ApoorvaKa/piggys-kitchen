using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Animator animator;
    float horizontal, vertical;
    public float speed;
    public Rigidbody2D rb;
    public bool canMove = true;

    void Update() {
        if (canMove) {
            horizontal = Input.GetAxisRaw("Horizontal");
            vertical = Input.GetAxisRaw("Vertical");
            animator.SetFloat("horizontal", horizontal);
            animator.SetFloat("vertical", vertical);
            animator.SetFloat("speed", horizontal * horizontal + vertical * vertical);

            rb.velocity = new Vector2(horizontal, vertical).normalized * speed;

        } else {
            rb.velocity = new Vector2(0, 0);
        }
    }
}
