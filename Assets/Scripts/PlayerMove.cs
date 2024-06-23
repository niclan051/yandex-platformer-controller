using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public Rigidbody2D rb;
    private Vector2 moveVector;
    public float speed = 2f;
    public Animator anim;
    public SpriteRenderer sr;
    public bool faceright = true;
    public int ImpulseLunge = 5000;
    private bool lockLunge = false;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();    
    }


    void Update()
    {
        Walk();
        Reflect();
        Lunge();
    }
    void Walk()
    {
        moveVector.x = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveVector.x * speed, rb.velocity.y);
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
}

