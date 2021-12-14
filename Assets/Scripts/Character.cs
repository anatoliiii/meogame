using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public float speed = 3.0f;
    public float jumpforce = 0.5f;
    public bool OnChair;
    public float SpeedChair;
    public Animator anim;
    public bool move;
    public GameObject Gun;

    private Rigidbody2D rigidbody2d;
    private bool IsGrounded = false;
    public Transform groundCheck;
    //радиус определения соприкосновения с землей
    private float groundRadius = 0.1f;
    //ссылка на слой, представляющий землю
    public LayerMask whatIsGround;

    private void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        move = true;
        anim = gameObject.GetComponent<Animator>();

    }

    private void FixedUpdate()
    {
        CheckGrund();
        if(IsGrounded && !Input.GetButton("Horizontal")) anim.SetInteger("State", 0);
        if(rigidbody2d.velocity.y!=0) anim.SetInteger("State", 2);
    }

    private void CheckGrund()
    {
        IsGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        // Debug.Log(IsGrounded);
        if (!IsGrounded)
        return;
    }

    public void Run(float _getAxisHorisontal) {
        if (move) {
            if(IsGrounded)anim.SetInteger("State", 1);
            float moveX = _getAxisHorisontal;
            Vector3 direction = transform.right * _getAxisHorisontal;
            Vector2 scale = gameObject.transform.localScale;
            transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);
            if (moveX > 0)
            {
                if (scale.x < 0)
                {
                    scale.x = -scale.x;
                    gameObject.transform.localScale = scale;
                }
            }
            else if (moveX < 0)
            {
                if (scale.x > 0)
                {
                    scale.x = -scale.x;
                    gameObject.transform.localScale = scale;
                }
            }
        }
       

    }

    public void Chairs(float _getAxisVertical)
    {
        if (OnChair && move)  {
            Vector3 direction = transform.up * _getAxisVertical;
            transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, SpeedChair * Time.deltaTime);
        }
    }
    public void Jump()
    {
        if (IsGrounded && move) {
            anim.SetInteger("State", 2);
            Vector2 speedY = rigidbody2d.velocity;
            speedY.y = 0;
            rigidbody2d.velocity = speedY;
            rigidbody2d.AddForce(transform.up * jumpforce, ForceMode2D.Impulse);
        }
    }

}

