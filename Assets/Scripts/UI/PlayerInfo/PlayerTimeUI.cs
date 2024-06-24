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

    private void Update()
    {
        _currentTime += Time.deltaTime;

        _playerTimeText.text = "TIME: " + _currentTime.ToString("F1");
    }

    public float GetCurrentTime()
    {
        return _currentTime;
    }
}
