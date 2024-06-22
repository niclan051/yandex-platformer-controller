using System;
using UnityEngine;

public class PlayerDashing : MonoBehaviour
{
    [SerializeField] private double dashSeconds;
    [SerializeField] private float dashForce;
    [SerializeField] private uint maxDashCount;
    private bool _dashing;
    private Vector2 _dashStart;
    private Vector2 _dashDirection;
    private uint _dashesLeft;
    private float _currentDashTime;
    
    private GroundCollision _groundCollision;
    private Rigidbody2D _rb2D;

    private void Start()
    {
        _groundCollision = GetComponentInChildren<GroundCollision>();
        _rb2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Vector2 soonToBeVelocity = _rb2D.velocity;

        if (_groundCollision.OnGround)
        {
            ResetDash();
        }
        
        if (!_dashing)
        {
            _dashDirection = new Vector2(Input.GetAxis("Dash Horizontal"), Input.GetAxis("Dash Vertical"));
            if (Input.GetButtonDown("Dash") && _dashesLeft > 0)
            {
                StartDash();
            }
        }
        else
        {
            UpdateDash(ref soonToBeVelocity);
            if (_currentDashTime >= dashSeconds)
            {
                EndDash();
                soonToBeVelocity = _dashDirection;
            }
        }

        _rb2D.velocity = soonToBeVelocity;
    }

    private void StartDash()
    {
        _dashing = true;
        _dashesLeft--;
        _currentDashTime = 0;
        _groundCollision.OnGround = false;
    }
    // ReSharper disable once RedundantAssignment
    private void UpdateDash(ref Vector2 soonToBeVelocity)
    {
        soonToBeVelocity = _dashDirection * dashForce;
        _currentDashTime += Time.deltaTime;
    }
    private void EndDash()
    {
        _dashing = false;
    }

    public void ResetDash(int count = -1)
    {
        if (count == -1)
        {
            _dashesLeft = maxDashCount;
        }
        else
        {
            _dashesLeft = Convert.ToUInt32(count);
        }
    }
}