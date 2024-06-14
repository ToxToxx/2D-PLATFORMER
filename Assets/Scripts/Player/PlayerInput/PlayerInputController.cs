using System;
using UnityEngine;
using UnityEngine.InputSystem;

using static UnityEngine.InputSystem.InputAction;

public class PlayerInputController : MonoBehaviour
{
    public static PlayerInputController Instance { get; private set; }

    private PlayerInputAction _playerInputAction;

    public event Action<CallbackContext> OnMovePlayerInputPerformed;
    public event Action<CallbackContext> OnJumpPlayerInputPerformed;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        _playerInputAction = new PlayerInputAction();
        _playerInputAction.Player.Enable();

        _playerInputAction.Player.Move.performed += OnMovePerformed;
        _playerInputAction.Player.Jump.performed += OnJumpPerformed;
    }

    private void OnMovePerformed(CallbackContext context)
    {
        OnMovePlayerInputPerformed?.Invoke(context);
    }

    private void OnJumpPerformed(CallbackContext context)
    {
        OnJumpPlayerInputPerformed?.Invoke(context);
    }

    private void OnDestroy()
    {
        if (_playerInputAction != null)
        {
            _playerInputAction.Player.Move.performed -= OnMovePerformed;
            _playerInputAction.Player.Jump.performed -= OnJumpPerformed;
            _playerInputAction.Dispose();
        }
    }

    public PlayerInputAction GetInputAction()
    {
        return _playerInputAction;
    }
}
