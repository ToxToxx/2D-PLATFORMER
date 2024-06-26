using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovementController : MonoBehaviour
{
    [SerializeField] private PlayerMovementCalculation _playerMovementCalculation;
    private Rigidbody2D _playerRigidbody;

    private bool _isMoving;

    private void Awake()
    {
        _playerRigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (_playerMovementCalculation != null)
        {
            MovePlayer();
        }
        else
        {
            Debug.LogError("PlayerMovementCalculationController is not initialized");
        }
    }

    public void MovePlayer()
    {
        Vector3 moveSpeed = _playerMovementCalculation.GetMovementVectorMoveSpeed();
        _playerRigidbody.velocity = new Vector2(moveSpeed.x, _playerRigidbody.velocity.y);
        FlipIfNeeded(moveSpeed.x);
    }

    private void FlipIfNeeded(float moveSpeed)
    {
        if (moveSpeed > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
            _isMoving = true;
        }
        else if (moveSpeed < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            _isMoving = true;
        } else
        {
            _isMoving = false;
        }
    }

    public bool GetPlayerIsMoving()
    {
        return _isMoving;
    }
}
