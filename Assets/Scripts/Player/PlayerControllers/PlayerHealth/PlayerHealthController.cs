using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    public static PlayerHealthController Instance;

    [SerializeField] private int _maxHealth = 3;
    private int _currentHealth;

    [SerializeField] private ScreenCanvasUI _loseScreenCanvas;

    public event System.Action<int> OnHealthChanged;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    private void Start()
    {
        _currentHealth = _maxHealth;
    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        if (_currentHealth < 0)
        {
            _currentHealth = 0;
        }

        OnHealthChanged?.Invoke(_currentHealth);

        if (_currentHealth == 0)
        {
            Die();
        }
    }

    public void Heal(int amount)
    {
        _currentHealth += amount;
        if (_currentHealth > _maxHealth)
        {
            _currentHealth = _maxHealth;
        }

        OnHealthChanged?.Invoke(_currentHealth);
    }

    private void Die()
    {
        _loseScreenCanvas.Show();
        Time.timeScale = 0;
    }

    public int GetCurrentHealth()
    {
        return _currentHealth;
    }
}
