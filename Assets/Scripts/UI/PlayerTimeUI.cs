using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerTimeUI : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI _playerTimeText;


    private void FixedUpdate()
    {
        _playerTimeText.text = "TIME: " + Time.time.ToString("F1");
    }
}
