using System;
using UnityEngine;

public class ReactiveProperty
{
    public Action<int> ValueChanged;
    private int _maxValue;
    private int _currentValue;

    public int CurrentValue 
    {
        get => _currentValue;
        private set
        {
            _currentValue = Mathf.Clamp(value, 0, _maxValue);
            ValueChanged?.Invoke(_currentValue);
        }
    }

    public ReactiveProperty(int startMaxValue = 100)
    {
        _maxValue = startMaxValue;
        CurrentValue = startMaxValue;
    }

    public void Increase(int value)
    {
        if(value < 0) return;
        CurrentValue += value;
    }

    public void Decrease(int value)
    {
        if(value < 0) return;
        CurrentValue -= value;
    }
}
