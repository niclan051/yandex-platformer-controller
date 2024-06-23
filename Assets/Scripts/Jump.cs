using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public float JumpForce = 0f;
    public Rigidbody2D rb;
    public bool onGround;
    public Transform GroundCheck;
    public float checkRadius = 0.5f;
    public LayerMask Ground;
    public Animator anim;
    private int jumpCount = 0;
    public int maxJumpValue = 2;
    void Start()
    {
       
    }

    void Update()
    {
        CheckingGround();
        Jump1();
    }

    void CheckingGround()
    {
        onGround = Physics2D.OverlapCircle(GroundCheck.position, checkRadius, Ground);
        anim.SetBool("onGround", onGround);
    }
    void Jump1()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(onGround)
            {
                rb.AddForce(Vector2.up * JumpForce);
            }
            else if (++jumpCount < maxJumpValue)
            {
                rb.AddForce(Vector2.up * JumpForce);
            }
        }

        if (onGround) { jumpCount = 0; }
    }
}


