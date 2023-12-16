using System;
using UnityEngine;

public class Health
{
    public Action<int> HealthChange;
    private int _maxHealth;
    private int _currentHealth;

    public int CurrentHealth 
    {
        get => _currentHealth;
        private set
        {
            _currentHealth = Mathf.Clamp(value, 0, _maxHealth);
            HealthChange?.Invoke(_currentHealth);
        }
    }

    public Health(int startMaxHealth)
    {
        _maxHealth = startMaxHealth;
        CurrentHealth = startMaxHealth;
    }

    public void Increase(int value)
    {
        if(value < 0) return;
        CurrentHealth += value;
    }

    public void Decrease(int value)
    {
        if(value < 0) return;
        CurrentHealth -= value;
    }
}
