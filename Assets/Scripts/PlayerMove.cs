using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public Rigidbody2D rb;
    private Vector2 moveVector;
    public int speed = 2;
    public Animator anim;
    public bool faceright = true;
    public int ImpulseLunge = 5000;
    private bool lockLunge = false;
    public int fastspeed = 6;
    private int realSpeed;
    private bool speedlock;

    private GroundCollision _groundCollision;
    
    void Start()
    {
        _groundCollision = GetComponentInChildren<GroundCollision>();
        
        rb = GetComponent<Rigidbody2D>();
        realSpeed = speed;
    }


    
    void Update()
    {
        Walk();
        Reflect();
        Run();
        Lunge();
    }
    void Walk()
    {
        moveVector.x = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveVector.x * realSpeed, rb.velocity.y);
        anim.SetFloat("MoveX", Mathf.Abs(moveVector.x));
    }
    void Reflect()
    {
        if ((moveVector.x > 0 && !faceright) || (moveVector.x < 0 && faceright))
        {
            transform.localScale *= new Vector2(-1, 1);
            faceright = !faceright;
        }
    }
    void Lunge()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl) && !lockLunge)
        {
            lockLunge = true;
            Invoke("LungeLock", 1f);
            rb.velocity = new Vector2(0, 0);

            if (!faceright) { rb.AddForce(Vector2.left * ImpulseLunge); }
            else { rb.AddForce(Vector2.right * ImpulseLunge); }
        }
    }
    void LungeLock()
    {
        lockLunge = false;
    }
    void Run()
    {

        if (Input.GetKey(KeyCode.LeftShift) && _groundCollision.OnGround)
        {
            realSpeed = fastspeed;
            if (Input.GetKeyDown(KeyCode.Space)) { speedlock = true; }
        
        }
        else
        {
            if (!speedlock) { realSpeed = speed; }
            else if (speedlock && _groundCollision.OnGround) { speedlock = false; }
            else { realSpeed = fastspeed;  }
        }
    }




}

