using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatMove : MonoBehaviour
{
    private Rigidbody2D rigidbody2d;
    [SerializeField]
    private float force;

    private void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (rigidbody2d.velocity.y ==0)
        {
            force = Random.Range(2, 7);
            rigidbody2d.AddForce(transform.up * force, ForceMode2D.Impulse);
        }
    }
}