using UnityEngine;

public class PlayerRegularMovement : MonoBehaviour
{
    [SerializeField] private float horizontalSpeedMultiplier;
    
    private Rigidbody2D _rb2D;

    private void Start()
    {
        _rb2D = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        Vector2 soonToBeVelocity = _rb2D.velocity;
        soonToBeVelocity.x = Input.GetAxis("Horizontal") * horizontalSpeedMultiplier;
        _rb2D.velocity = soonToBeVelocity;
    }
}