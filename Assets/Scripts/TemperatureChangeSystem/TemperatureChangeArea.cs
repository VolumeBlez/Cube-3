using UnityEngine;

public class TemperatureChangeArea : MonoBehaviour
{
    [SerializeField] private TemperatureChangePreset _preset;

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out PlayerFreeze freeze))
        {
            freeze.SetTemperaturePreset(_preset);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.TryGetComponent(out PlayerFreeze freeze))
        {
            freeze.SetDefaultTemperaturePreset();
        }
    }
}
