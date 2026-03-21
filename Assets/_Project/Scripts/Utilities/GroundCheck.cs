using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    [SerializeField] private LayerMask _groundLayer; // Check only the ground layer
    public bool IsGrounded;

    private void Update() // Constantly check if the player's feet are touching the ground
    {
        IsGrounded = Physics.CheckSphere(transform.position, 0.2f, _groundLayer);
    }
}
