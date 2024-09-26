using UnityEngine;

namespace VB
{
    public class FreezeArea : MonoBehaviour
    {
        [SerializeField] private int _freezeDeltaValue;
        private IFreezable _freezable;

        private void OnTriggerEnter(Collider other)
        {
            if(other.TryGetComponent(out IFreezable IFreezable))
            {
                _freezable = IFreezable;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if(other.GetComponent<IFreezable>() != null)
            {
                _freezable = null;
            }
        }

        private void FixedUpdate()
        {
            _freezable?.ApplyFreeze(_freezeDeltaValue);
        }
    }
}
