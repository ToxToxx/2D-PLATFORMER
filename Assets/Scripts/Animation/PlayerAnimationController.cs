using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    [SerializeField] private PlayerMovementController _playerMovementController;
    [SerializeField] private Animator _animator; 

    private void Update()
    {
        ControlPlayerRunningAnimation();
    }

    private void ControlPlayerRunningAnimation()
    {
        _animator.SetBool("IsRunning", _playerMovementController.GetPlayerIsMoving());
    }
}
