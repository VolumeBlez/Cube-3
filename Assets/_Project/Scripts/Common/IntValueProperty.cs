using System;
using UnityEngine;

public class IntValueProperty
{
    public Action<int> ValueChanged;
    public Action ValueReachedMinimum;

    private int _maxValue;
    private int _minValue;
    private int _currentValue;

    public int CurrentValue 
    {
        get => _currentValue;
        private set
        {
            _currentValue = Mathf.Clamp(value, _minValue, _maxValue);
            ValueChanged?.Invoke(_currentValue);

            if(_currentValue == _minValue)
                ValueReachedMinimum?.Invoke();
        }
    }

    public IntValueProperty(int startMaxValue = 100, int startMinValue = 0)
    {
        _maxValue = startMaxValue;
        _minValue = startMinValue;
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
