using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WinningScreenTimeUI : MonoBehaviour
{
    [SerializeField] private PlayerTimeUI _playerTimeUI;
    [SerializeField] private TextMeshProUGUI _levelTimeText;
    private void OnEnable()
    {
        _levelTimeText.text = "TIME: " + _playerTimeUI.GetCurrentTime().ToString();
    }
}
