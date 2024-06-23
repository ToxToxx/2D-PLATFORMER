using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerTimeUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _playerTimeText;

    private float _currentTime = 0;

    private void Start()
    {
        _currentTime = 0;
    }
    private void FixedUpdate()
    {
        _playerTimeText.text = "TIME: " + _currentTime.ToString("F1");
        _currentTime = Time.fixedTime;
    }

    public float GetCurrentTime()
    {
        return _currentTime;
    }
}
