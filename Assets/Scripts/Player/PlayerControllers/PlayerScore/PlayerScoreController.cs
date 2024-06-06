using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScoreController : MonoBehaviour
{
    public static PlayerScoreController Instance;
    [SerializeField] private float _playerScore;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void AddScore(float value)
    {
        _playerScore += value;
    }

    public float GetScore()
    {
        return _playerScore;
    }
}
