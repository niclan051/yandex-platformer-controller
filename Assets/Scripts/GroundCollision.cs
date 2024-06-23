using UnityEngine;

public class GroundCollision : MonoBehaviour
{
    private Collider2D _collider;
    [SerializeField] private LayerMask groundLayer;
    
    public bool OnGround { get; private set; }

    private void Start()
    {
        _collider = GetComponent<Collider2D>();
    }
    private void Update()
    {
        OnGround = _collider.IsTouchingLayers(groundLayer);
    }
}
