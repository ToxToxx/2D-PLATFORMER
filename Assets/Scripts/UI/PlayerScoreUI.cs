using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerScoreUI : MonoBehaviour
{
    private PlayerScoreController _playerScoreController;

    [SerializeField] private TextMeshProUGUI _playerScoreText;
    private void Start()
    {
        _playerScoreController = PlayerScoreController.Instance;
    }

    private void Update()
    {
        _playerScoreText.text = "Score: " + _playerScoreController.GetScore().ToString();
    }
}
