using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace VB
{
    public class PlayerInteractor : MonoBehaviour
    {
        private InputHandler _inputHandler;
        private PlayerController _playerController;
        private RaycastHit _hitInfo;

        [Inject]
        public void Setup(InputHandler inputHandler, PlayerController playerController)
        {
            _inputHandler = inputHandler;
            _playerController = playerController;

            SubscribeOnInputEvents();
        }

        public void PerformInteract()
        {
            Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());

            if(Physics.Raycast(ray, out _hitInfo, 50f))
            {
                if(_hitInfo.transform.TryGetComponent(out ItemView itemView))
                {
                    OnItemInteracted(itemView);
                }
            }
        }

        private void OnItemInteracted(ItemView itemView)
        {
            if(_playerController.TryToAddToInventory(itemView.Item))
                itemView.DestroyItemView();
        }

        private void OnDestroy() => UnSubscribeOnInputEvents();

        private void SubscribeOnInputEvents() => _inputHandler.Input.Gameplay.Interact.performed += ctx => PerformInteract();
        private void UnSubscribeOnInputEvents() => _inputHandler.Input.Gameplay.Interact.performed -= ctx => PerformInteract();
    }
}
