using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    private PlayerScoreController _playerScoreController;
    
    [SerializeField] private LevelManager _levelManager;

    [SerializeField] private float _coinValue;
    private void Start()
    {
        _playerScoreController = PlayerScoreController.Instance;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerMovementController>())
        {
            _playerScoreController.AddScore(_coinValue);
            _levelManager.CollectCoin();
            Destroy(gameObject);
        }
    }
}
