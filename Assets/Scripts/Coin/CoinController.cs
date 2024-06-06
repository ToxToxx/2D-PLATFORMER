using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    private PlayerScoreController _playerScoreController;

    [SerializeField] private float _coinValue;
    private void Start()
    {
        _playerScoreController = PlayerScoreController.Instance;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.gameObject.CompareTag("Player"))
        {
            _playerScoreController.AddScore(_coinValue);
            Destroy(gameObject);
        }
    }
}
