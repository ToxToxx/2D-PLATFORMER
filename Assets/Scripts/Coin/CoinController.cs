using UnityEngine;

public class CoinController : MonoBehaviour
{
    private LevelManager _levelManager;
    private PlayerScoreController _scoreController;

    [SerializeField] private float _coinValue;
    private void Start()
    {
        _levelManager = FindObjectOfType<LevelManager>();
        _scoreController = PlayerScoreController.Instance;
        if (_levelManager == null)
        {
            Debug.LogError("LevelManager not found in the scene.");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerMovementController>())
        {
            _scoreController.AddScore(_coinValue);
            if (_levelManager != null)
            {
                _levelManager.CollectCoin();
                Destroy(gameObject);
            }
            else
            {
                Debug.LogWarning("LevelManager reference is missing in CoinController.");
            }
        }
    }
}
