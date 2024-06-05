using UnityEngine;
using System;
using UnityEngine.InputSystem;

public class PlayerMovementCalculation : MonoBehaviour
{
    [SerializeField] private PlayerMovementSO _playerMovementConfig;
    private PlayerInputController _playerInputSystem;

    private void Awake()
    {
        _playerInputSystem = PlayerInputController.Instance;
        if (_playerInputSystem != null)
        {
            _playerInputSystem.OnMovePlayerInputPerformed += OnPlayerInputMove;
        }
        else
        {
            Debug.LogError("PlayerInputController is not initialized");
        }
    }

    private void OnPlayerInputMove(InputAction.CallbackContext context)
    {
        Debug.Log("Movement");
    }

    public Vector2 GetMovementVectorNormalized()
    {
        if (_playerInputSystem == null)
        {
            Debug.LogError("PlayerInputController is null in GetMovementVectorNormalized");
            return Vector2.zero;
        }

        Vector2 inputVector = _playerInputSystem.GetInputAction().Player.Move.ReadValue<Vector2>();
        return inputVector.normalized;
    }

    public Vector3 GetMovementVectorMoveSpeed()
    {
        float moveSpeed = _playerMovementConfig.Speed;
        Vector2 inputVector = GetMovementVectorNormalized();
        return new Vector3(inputVector.x * moveSpeed, inputVector.y, 0f);
    }

    private void OnDestroy()
    {
        if (_playerInputSystem != null)
        {
            _playerInputSystem.OnMovePlayerInputPerformed -= OnPlayerInputMove;
        }
    }
}
