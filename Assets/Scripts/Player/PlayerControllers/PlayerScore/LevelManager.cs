using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private Loader.Scene _nextLevel;
    [SerializeField] private int _totalCoins;
    private int _collectedCoins;

    private void Start()
    {
        _collectedCoins = 0;
    }

    public void CollectCoin()
    {
        _collectedCoins++;
        if (_collectedCoins >= _totalCoins)
        {
            LoadNextLevel();
        }
    }

    private void LoadNextLevel()
    {
        Loader.Load(_nextLevel);
    }
}
