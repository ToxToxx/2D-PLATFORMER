using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextLevelButtonUI : MonoBehaviour
{
    [SerializeField] private Loader.Scene _nextLevel;
    [SerializeField] private LevelManager _levelManager;
    [SerializeField] private Button _nextLevelButton;
    private void LoadNextLevel()
    {
        Loader.Load(_nextLevel);
        _levelManager.HideWinningScreen();
        Time.timeScale = 1.0f;
    }

    private void OnEnable()
    {
        _nextLevelButton.onClick.AddListener(() =>
        {
            LoadNextLevel();
        });
    }
}
