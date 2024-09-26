using UnityEngine;
using Zenject;

namespace VB
{
    public class PlayerTrapPlacer : MonoBehaviour
    {
        [SerializeField] private GameObject _trapPrefab;
        [SerializeField] private Transform _placePoint;
        private InputHandler _inputHandler;
        private PlayerController _controller;

        [Inject]
        private void Setup(InputHandler inputHandler, PlayerController controller)
        {
            _inputHandler = inputHandler;
            _controller = controller;

            SubscribeOnInputEvents();
        }

        private void PlaceTrap()
        {
            if(_controller.TryToRemoveFromInventory(ItemType.Trap) == true)
            {
                Instantiate(_trapPrefab, _placePoint.position, Quaternion.identity, null);
            }
        }

        private void SubscribeOnInputEvents() => _inputHandler.Input.Gameplay.Place.performed += ctx => PlaceTrap();
        private void OnDestroy() => _inputHandler.Input.Gameplay.Place.performed -= ctx => PlaceTrap();
    }
}
