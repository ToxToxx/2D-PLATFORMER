using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerJump : MonoBehaviour
{
    [SerializeField] private PlayerMovementSO _playerMovementSO;

    private Rigidbody2D _rigidbody;
    private PlayerInputController _playerInputSystem;
    [SerializeField] private bool _isGrounded;
    [SerializeField] private bool _isJumping;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        _playerInputSystem = PlayerInputController.Instance;
        if (_playerInputSystem != null)
        {
            _playerInputSystem.OnJumpPlayerInputPerformed += OnPlayerInputJump;
        }
        else
        {
            Debug.LogError("PlayerInputController is not initialized");
        }
    }

    private void FixedUpdate()
    {
        if (_isJumping && _isGrounded)
        {
            _rigidbody.AddForce(Vector2.up * _playerMovementSO.JumpPower, ForceMode2D.Impulse);
            _isJumping = false;
        }
    }

    private void OnPlayerInputJump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _isJumping = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _isGrounded = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        _isGrounded = false;
    }
    private void OnDestroy()
    {
        if (_playerInputSystem != null)
        {
            _playerInputSystem.OnJumpPlayerInputPerformed -= OnPlayerInputJump;
        }
    }
}
