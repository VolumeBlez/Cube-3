using UnityEngine;

namespace VB
{
    public class HeatArea : MonoBehaviour
    {
        [SerializeField] private int _heatDeltaValue;
        private IHeatable _heatable;

        private void OnTriggerEnter(Collider other)
        {
            if(other.TryGetComponent(out IHeatable IHeatable))
            {
                _heatable = IHeatable;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if(other.GetComponent<IHeatable>() != null)
            {
                _heatable = null;
            }
        }

        private void FixedUpdate()
        {
            _heatable?.ApplyHeat(_heatDeltaValue);
        }
    }
}
