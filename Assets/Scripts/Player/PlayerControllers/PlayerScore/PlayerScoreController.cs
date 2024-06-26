using System;
using UnityEngine;

public class PlayerScoreController : MonoBehaviour
{
    public static PlayerScoreController Instance;
    public event EventHandler OnScoreChanged;
    [SerializeField] private float _playerScore;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    public void AddScore(float value)
    {
        _playerScore += value;
        OnScoreChanged?.Invoke(this, new EventArgs());
    }

    public float GetScore()
    {
        return _playerScore;
    }
}
