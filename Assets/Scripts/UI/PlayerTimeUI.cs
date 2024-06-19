using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerTimeUI : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI _playerTimeText;

    private float _currentTime;

    private void FixedUpdate()
    {
        _playerTimeText.text = "TIME: " + Time.time.ToString("F1");
        _currentTime = Time.time;
    }

    public float GetCurrentTime()
    {
        return _currentTime;
    }
}
