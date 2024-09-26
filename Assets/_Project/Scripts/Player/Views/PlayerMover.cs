using UnityEngine;
using Zenject;

namespace VB
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerMover : MonoBehaviour
    {
        [SerializeField] private Transform _motorObject;
        [SerializeField] private CharacterController _motorController;

        private InputHandler _inputHandler;
        private PlayerData _data;
        private Transform _cameraTransform;
        private Vector2 _moveDirection;
        private Vector3 _groundVelocity;
        private float _smoothVelocity;

        [Inject]
        public void Setup(InputHandler handler, PlayerController controller)
        {
            _inputHandler = handler;
            _cameraTransform = Camera.main.transform;
            _data = controller.GetPlayerData();

            SubscribeOnInputEvents();
        }

        public void SetDirection(Vector2 direction) => _moveDirection = direction;

        public void ResetDirection() => _moveDirection = Vector3.zero;

        private void OnDestroy() => UnSubscribeOnInputEvents();

        private void Update() => HandleMovement();

        private void HandleMovement()
        {
            Vector3 direction = new Vector3(_moveDirection.x, 0, _moveDirection.y);

            if(direction.magnitude >= 0.1f)
            {
                float rotationAngle = Mathf.Atan2(_moveDirection.x, _moveDirection.y) * Mathf.Rad2Deg + _cameraTransform.eulerAngles.y;
                float angle = Mathf.SmoothDampAngle(_motorObject.eulerAngles.y, rotationAngle, ref _smoothVelocity, _data.RotateSmooth);

                _motorObject.rotation = Quaternion.Euler(0f, angle, 0f);
                Vector3 move = Quaternion.Euler(0f, rotationAngle, 0f) * Vector3.forward;

                _motorController.Move(move.normalized * _data.MoveSpeed * Time.deltaTime);
            }

            var groundedPlayer = _motorController.isGrounded;
            if(groundedPlayer && _groundVelocity.y < 0f)
            {
                _groundVelocity.y = 0f;
            }
            _groundVelocity.y += -9.81f * Time.deltaTime;
            _motorController.Move(_groundVelocity * Time.deltaTime);
        }

        private void SubscribeOnInputEvents()
        {
            _inputHandler.Input.Gameplay.Movement.performed += ctx => SetDirection(ctx.ReadValue<Vector2>());
            _inputHandler.Input.Gameplay.Movement.canceled += ctx => ResetDirection();
        }

        private void UnSubscribeOnInputEvents()
        {
            _inputHandler.Input.Gameplay.Movement.performed -= ctx => SetDirection(ctx.ReadValue<Vector2>());
            _inputHandler.Input.Gameplay.Movement.canceled -= ctx => ResetDirection();
        }
    }
}
