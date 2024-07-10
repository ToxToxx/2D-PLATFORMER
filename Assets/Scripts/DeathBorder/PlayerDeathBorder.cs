using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerDeathBorder : MonoBehaviour
{
    [SerializeField] private GameObject _respawnPoint;
    [SerializeField] private int _deathBorderDamage;

    private PlayerHealthController _playerHealthController;

    private void Start()
    {
        _playerHealthController = PlayerHealthController.Instance;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerMovementController>())
        {
            collision.gameObject.transform.position = _respawnPoint.transform.position;
            _playerHealthController.TakeDamage(_deathBorderDamage);
        }
    }
}
