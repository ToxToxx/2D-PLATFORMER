using UnityEngine;

public class CoinController : MonoBehaviour
{
    private PlayerScoreController _scoreController;

    [SerializeField] private float _coinValue;
    private void Start()
    {
        _scoreController = PlayerScoreController.Instance;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerMovementController>())
        {
            _scoreController.AddScore(_coinValue);
            Destroy(gameObject);
        }
    }
}
