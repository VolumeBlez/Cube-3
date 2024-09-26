using UnityEngine;

namespace VB
{
    public class PlayerController : IStartGameListener, IPauseGameListener
    {
        private PlayerModel _playerModel;
        private bool _isEnabled;

        public PlayerController(PlayerModel playerModel)
        {
            _playerModel = playerModel;
        }

        public void OnStartGame() => _isEnabled = true;

        public void OnPauseGame() => _isEnabled = false;

        public void UpdatePosition(Vector3 newPos)
        {
            if(newPos == _playerModel.CurrentPosition && !_isEnabled)
                return;
            
            _playerModel.UpdatePosition(newPos);
        }

        public void ApplyFreeze(int value)
        {
            if(value <= 0 && !_isEnabled)
                return;

            _playerModel.Freezing.Increase(value);
        }

        public void ApplyHeat(int value)
        {
            if(value <= 0 && !_isEnabled)
                return;

            _playerModel.Freezing.Decrease(value);
        }

        public void ApplyDamage(int value)
        {
            if(value <= 0 && !_isEnabled)
                return;
                
            _playerModel.Health.Decrease(value);
        }
    
        public bool TryToRemoveFromInventory(ItemType item)
        {
            return _playerModel.Inventory.TryRemove(item);
        }

        public bool TryToAddToInventory(IItem item)
        {
            return _playerModel.Inventory.TryAdd(item);
        }

        public PlayerData GetPlayerData()
        {
            return _playerModel.Data;
        }
    }
}
