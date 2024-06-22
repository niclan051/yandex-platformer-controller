using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WallWalk : MonoBehaviour
{
    public bool onWall;
    public LayerMask Wall;
    public Transform WallCheckDown;
    public Transform WallCheckUp;
    private float WallCheckRadiusDown;
    private float WallCheckRadiusUp;

    void CheckingWall()
    {
        onWall = (Physics2D.OverlapCircle(WallCheckUp.position, WallCheckRadiusDown, Wall) && Physics2D.OverlapCircle(WallCheckDown.position, WallCheckRadiusDown, Wall));
    }
    private void Update()
    {
        CheckingWall();
    }
    private void Start()
    {
        WallCheckRadiusUp = WallCheckUp.GetComponent<CircleCollider2D>().radius;
        WallCheckRadiusDown = WallCheckDown.GetComponent<CircleCollider2D>().radius;
    }
}
