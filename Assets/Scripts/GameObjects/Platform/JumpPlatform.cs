using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPlatform : MonoBehaviour
{
    private Animator anim;
    public int JumpForce;

    private void Awake()
    {
        anim = gameObject.GetComponentInChildren<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Rigidbody2D rigidbody2d = collision.GetComponent<Rigidbody2D>();
            Vector2 speedY = rigidbody2d.velocity;
            speedY.y = 0;
            rigidbody2d.velocity = speedY;
            rigidbody2d.AddForce(transform.up * JumpForce, ForceMode2D.Impulse);
            anim.Play("JumpPlatform");
        }
    }
}
