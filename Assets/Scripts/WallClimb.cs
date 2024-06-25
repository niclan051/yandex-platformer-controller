using UnityEngine;

public class WallClimb : MonoBehaviour
{
    public bool OnWall { get; private set; }

    [SerializeField] private float speedMultiplier;
    [SerializeField] private float wallJumpForce;
    [SerializeField] private Collider2D wallCheck;
    [SerializeField] private LayerMask wallLayer;

    private PlayerMove _playerMove;
    private Rigidbody2D _rb;

    private void Start()
    {
        _playerMove = GetComponent<PlayerMove>();
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        OnWall = wallCheck.IsTouchingLayers(wallLayer) && Input.GetKey(KeyCode.LeftShift);

        WallJump();
        if (OnWall)
        {
            _rb.velocity = new Vector2(0, Input.GetAxis("Dash Vertical") * speedMultiplier);
        }
    }

    private void WallJump()
    {
        if (OnWall && Input.GetKeyDown(KeyCode.Space))
        {
            OnWall = false;
            _rb.velocity = Vector2.zero;
            _rb.AddForce(new Vector2(_playerMove.faceright ? -1 : 1, 1) * wallJumpForce);
        }
    }
}