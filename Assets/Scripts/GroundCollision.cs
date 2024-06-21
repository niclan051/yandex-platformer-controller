using UnityEngine;

public class GroundCollision : MonoBehaviour {
    public bool OnGround { get; set; }
    
    private void OnTriggerStay2D(Collider2D other)
    {
        OnGround = true;
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        OnGround = false;
    }
}
