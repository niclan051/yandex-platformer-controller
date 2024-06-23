using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public float JumpForce = 0f;
    public Rigidbody2D rb;
    public Animator anim;
    private int jumpCount = 0;
    public int maxJumpValue = 2;

    private GroundCollision _groundCollision;
    
    void Start()
    {
        _groundCollision = GetComponentInChildren<GroundCollision>();
        
        WallcheckRadiusUp = ChekingWallUp.GetComponent<CircleCollider2D>().radius;
        WallcheckRadiusDown = ChekingWallDown.GetComponent<CircleCollider2D>().radius;
    }

    void Update()
    {
        CheckingWall();
        CheckingGround();
        Jump1();
    }

    void CheckingGround()
    {
        anim.SetBool("onGround", _groundCollision.OnGround);
    }
    void Jump1()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            Physics2D.IgnoreLayerCollision(8, 9, true);
            Invoke("IgnoreLayerOff", 0.5f);
        }
        
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(_groundCollision.OnGround)
            {
                rb.velocity = new Vector2(rb.velocity.x, 0);
                rb.AddForce(Vector2.up * JumpForce);
            }
            else if (++jumpCount < maxJumpValue)
            {
                rb.AddForce(Vector2.up * JumpForce);
            }
        }

        if (_groundCollision.OnGround) { jumpCount = 0; }
    }
    void IgnoreLayerOff()
    {
        Physics2D.IgnoreLayerCollision(8, 9, false);
    }

    public bool onWall;
    public Transform ChekingWallUp;
    public Transform ChekingWallDown;
    public float WallcheckRadiusUp;
    public float WallcheckRadiusDown;
    public LayerMask Wall;

    void CheckingWall()
    {
        onWall= (Physics2D.OverlapCircle(ChekingWallUp.position, WallcheckRadiusUp, Wall) && Physics2D.OverlapCircle(ChekingWallDown.position, WallcheckRadiusDown, Wall));
    }
}


