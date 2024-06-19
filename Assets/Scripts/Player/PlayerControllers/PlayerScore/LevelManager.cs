using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private GameObject _winningScreenCanvas;
    [SerializeField] private int _totalCoins;
    [SerializeField] private GameObject _playerGameObject;
    [SerializeField] private GameObject _respawnPoint;

    private int _collectedCoins;

    private void Start()
    {
        _collectedCoins = 0;
        if (_playerGameObject == null)
        {
            Debug.LogError("Player GameObject is not assigned in LevelManager.");
        }
        if (_respawnPoint == null)
        {
            Debug.LogError("Respawn Point GameObject is not assigned in LevelManager.");
        }
    }

    public void CollectCoin()
    {
        _collectedCoins++;
        if (_collectedCoins >= _totalCoins)
        {
            if (_playerGameObject != null)
            {
                _playerGameObject.transform.position = _respawnPoint.transform.position;
                Time.timeScale = 0f;
                ShowWinningScreen();
            }
            else
            {
                Debug.LogWarning("Player GameObject or Respawn Point is missing.");
            }
        }
    }

    private void ShowWinningScreen()
    {
        _winningScreenCanvas.SetActive(true);
    }
    public void HideWinningScreen()
    {
        _winningScreenCanvas.SetActive(false);
    }
}
