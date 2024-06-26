using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private ScreenCanvasUI _winningScreenCanvas;
    [SerializeField] private int _totalScore;
    [SerializeField] private GameObject _playerGameObject;
    [SerializeField] private GameObject _respawnPoint;

    private PlayerScoreController _scoreController;


    private void Start()
    {
        _scoreController = PlayerScoreController.Instance;
        _scoreController.OnScoreChanged += CheckIfAllCoinsCollected;
        if (_playerGameObject == null)
        {
            Debug.LogError("Player GameObject is not assigned in LevelManager.");
        }
        if (_respawnPoint == null)
        {
            Debug.LogError("Respawn Point GameObject is not assigned in LevelManager.");
        }
    }

    private void CheckIfAllCoinsCollected(object sender, System.EventArgs e)
    {
        if (_scoreController.GetScore() >= _totalScore)
        {
            if (_playerGameObject != null)
            {
               FinishGame();
            }
            else
            {
                Debug.LogWarning("Player GameObject or Respawn Point is missing.");
            }
        }
    }

    public void FinishGame()
    {
        _playerGameObject.transform.position = _respawnPoint.transform.position;
        Time.timeScale = 0f;
        _winningScreenCanvas.Show();
    }

}
