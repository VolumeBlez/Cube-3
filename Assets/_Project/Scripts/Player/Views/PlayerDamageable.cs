using UnityEngine;
using Zenject;

namespace VB
{
    public class PlayerDamageable : MonoBehaviour, IDamageable
    {
        private PlayerController _playerController;

        [Inject]
        public void Setup(PlayerController playerController)
        {
            _playerController = playerController;
        }

        public void ApplyDamage(int value)
        {
            _playerController.ApplyDamage(value);
        }
    }
}
