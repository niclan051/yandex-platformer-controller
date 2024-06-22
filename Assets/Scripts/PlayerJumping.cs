using UnityEngine;

public class PlayerJumping : MonoBehaviour
{
    [SerializeField] private float jumpMultiplier;
    
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
        if (_groundCollision.OnGround && Input.GetButton("Jump"))
        {
            soonToBeVelocity.y = jumpMultiplier;
        }
        _rb2D.velocity = soonToBeVelocity;
    }
}