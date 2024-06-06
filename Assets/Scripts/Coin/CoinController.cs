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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _playerScoreController.AddScore(_coinValue);
            Destroy(gameObject);
        }
    }
}
