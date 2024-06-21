using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Regular movement")]
    [SerializeField] private float horizontalSpeedMultiplier;
    [SerializeField] private float jumpMultiplier;

    [Header("Dashing")]
    [SerializeField] private float dashTime; // in seconds
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
        
        // regular movement
        soonToBeVelocity.x = Input.GetAxis("Horizontal") * horizontalSpeedMultiplier;
        if (_groundCollision.OnGround)
        {
            _groundCollision.OnGround = false;
            
            if (Input.GetButton("Jump")) soonToBeVelocity.y = jumpMultiplier;

            _dashesLeft = maxDashCount;
        }

        // dashing
        if (!_dashing)
        {
            _dashDirection = new Vector2(Input.GetAxis("Dash Horizontal"), Input.GetAxis("Dash Vertical"));
            if (Input.GetButtonDown("Dash") && _dashesLeft > 0)
            {
                _dashing = true;
                _dashesLeft--;
                _currentDashTime = 0;
            }
        }
        else
        {
            soonToBeVelocity = _dashDirection * dashForce;
            _currentDashTime += Time.deltaTime;
            if (_currentDashTime >= dashTime)
            {
                _dashing = false;
                soonToBeVelocity = _dashDirection;
            }
        }

        _rb2D.velocity = soonToBeVelocity;
    }
}