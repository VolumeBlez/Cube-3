using UnityEngine;

public class TemperatureChangePreset : ScriptableObject
{
    [field: SerializeField] public TemperatureChangeType Type { get; private set; }
    [field: SerializeField] public int Value { get; private set; }
}
