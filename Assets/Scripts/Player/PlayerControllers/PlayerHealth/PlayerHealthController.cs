using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    [SerializeField] private int maxHealth = 3; 
    private int _currentHealth; 

    public event System.Action<int> OnHealthChanged;

    private void Start()
    {
        _currentHealth = maxHealth; 
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
        if (_currentHealth > maxHealth)
        {
            _currentHealth = maxHealth;
        }

        OnHealthChanged?.Invoke(_currentHealth);
    }

    private void Die()
    {
        Debug.Log("Player has died");
    }
}
