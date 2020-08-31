using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _jumpForce;
    [SerializeField] private LayerMask _whatIsGround;
    [SerializeField] private float _requiredDistanceToJump;
    private Rigidbody2D _rigidBody;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    public void Jump()
    {
        if (IsGrounded())
        {
            _rigidBody.AddForce(Vector2.up * _jumpForce);
        }
    }

    private bool IsGrounded()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.down, _requiredDistanceToJump, _whatIsGround);
        return hitInfo.collider != null;
    }
}
