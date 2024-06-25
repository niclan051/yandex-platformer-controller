using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    public Animator anim;
    public Rigidbody2D rb;
    public int lungeimpulse = 5000;
    void Start()
    {
        
    }

    void Update()
    {
        Lunge(); 
    }
    void Lunge()
    {
        if(Input.GetKeyDown(KeyCode.LeftControl))
        {
            rb.velocity = new Vector2(0, 0);
            anim.StopPlayback();
            anim.Play("Dash");
        }
    }






}
