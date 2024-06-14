using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private Loader.Scene _nextLevel;
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
            if (_playerGameObject != null) //&& _respawnPoint != null)
            {
                _playerGameObject.transform.position = _respawnPoint.transform.position;
                LoadNextLevel();
            }
            else
            {
                Debug.LogWarning("Player GameObject or Respawn Point is missing.");
            }
        }
    }

    private void LoadNextLevel()
    {
        Loader.Load(_nextLevel);
    }
}
