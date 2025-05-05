using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Transform GroundCheck;
    private Zproject _defaultPlayerActions;
    private InputAction _moveAction;
    private Rigidbody _rigidBody;
    private readonly float _movementSpeed = 4f;
    private readonly float _jumpForce = 3f;
    private bool _isGrounded;
    private LayerMask _groundLayerMask;

    private void Awake()
    {
        _defaultPlayerActions = new Zproject();
        _rigidBody = GetComponent<Rigidbody>();
        _groundLayerMask = LayerMask.GetMask("Ground");
    }

    private void OnEnable()
    {
        _moveAction = _defaultPlayerActions.Player.Move;
        _moveAction.Enable();
        _defaultPlayerActions.Player.Jump.Enable();
        _defaultPlayerActions.Player.Jump.performed += OnJump;
    }

    private void OnDisable()
    {
        _moveAction = _defaultPlayerActions.Player.Move;
        _moveAction.Disable();
    }

    private void FixedUpdate()
    {
        _isGrounded = Physics.Raycast(GroundCheck.position, Vector3.down, 0.05f);

            Vector2 moveDir = _moveAction.ReadValue<Vector2>();
        Vector3 vel = _rigidBody.linearVelocity;
        vel.x = _movementSpeed * moveDir.x;
        vel.z = _movementSpeed * moveDir.y;
        _rigidBody.linearVelocity = vel;
    }

    private void OnJump(InputAction.CallbackContext context)
    {
        if (_isGrounded)
        {
            Debug.Log("au sol");
            _rigidBody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
        }
    }
}
