using UnityEngine;
using Zenject;

namespace VB
{
    public class PlayerTemperatureImpactApplier : MonoBehaviour, IHeatable, IFreezable
    {
        private PlayerController _playerController;

        [Inject]
        public void Setup(PlayerController playerController)
        {
            _playerController = playerController;
        }

        public void ApplyFreeze(int value)
        {
            _playerController.ApplyFreeze(value);
        }

        public void ApplyHeat(int value)
        {
            _playerController.ApplyHeat(value);
        }
    }
}
