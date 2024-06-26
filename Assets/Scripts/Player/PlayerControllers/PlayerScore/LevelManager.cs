using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private ScreenCanvasUI _winningScreenCanvas;
    [SerializeField] private int _totalScore = 4;
    [SerializeField] private GameObject _playerGameObject;

    private PlayerScoreController _scoreController;


    private void Start()
    {
        _scoreController = PlayerScoreController.Instance;
        _scoreController.OnScoreChanged += CheckIfAllCoinsCollected;
        if (_playerGameObject == null)
        {
            Debug.LogError("Player GameObject is not assigned in LevelManager.");
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
        Time.timeScale = 0f;
        _winningScreenCanvas.Show();
    }

}
