using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeLevelButtonUI : MonoBehaviour
{
    [SerializeField] private Loader.Scene _nextLevel;
    [SerializeField] private Button _nextLevelButton;
    [SerializeField] private ScreenCanvasUI _screenCanvasUI;

    private void LoadNextLevel()
    {
        Loader.Load(_nextLevel);
        Time.timeScale = 1.0f;
        _screenCanvasUI.Hide();
    }

    private void OnEnable()
    {
        if (_nextLevelButton != null)
        {
            _nextLevelButton.onClick.AddListener(OnNextLevelButtonClick);
        }
        else
        {
            Debug.LogError("NextLevelButton reference is missing.");
        }
    }

    private void OnDisable()
    {
        if (_nextLevelButton != null)
        {
            _nextLevelButton.onClick.RemoveListener(OnNextLevelButtonClick);
        }
    }

    private void OnNextLevelButtonClick()
    {
        LoadNextLevel();
    }
}
