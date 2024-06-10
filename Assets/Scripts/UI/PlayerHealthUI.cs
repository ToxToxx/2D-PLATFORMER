using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerHealthUI : MonoBehaviour
{
    private PlayerHealthController _playerHealthController;

    [SerializeField] private TextMeshProUGUI _playerHealthText;
    private void Start()
    {
        _playerHealthController = PlayerHealthController.Instance;
    }

    private void Update()
    {
        _playerHealthText.text = "HEALTH: " + _playerHealthController.GetCurrentHealth().ToString();
    }
}
