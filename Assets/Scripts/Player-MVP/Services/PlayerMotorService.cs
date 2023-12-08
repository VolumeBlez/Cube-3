using UnityEngine;

public class PlayerMotorService : BasePlayerService
{
    private readonly CharacterController _controller;
    private readonly Transform _motorObject;
    private readonly Transform _cameraTransform;
    private float _smoothVelocity;
    private Vector3 _groundVelocity;
    private float _smooth;
    
    public PlayerMotorService(IPlayerModel model, IPlayerPresenter presenter) : base(model, presenter)
    {
        _controller = Model.Data.Controller;
        //_cameraTransform = Model.Data.Camera.transform;
        _cameraTransform = Camera.main.transform;
        _motorObject = Model.Data.MotorObject;
        _smooth = Model.Data.RotateSmooth;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void SetMove(Vector2 moveDirection)
    {
        Vector3 direction = new Vector3(moveDirection.x, 0, moveDirection.y);

        if(direction.magnitude >= 0.1f)
        {
            float rotationAngle = Mathf.Atan2(moveDirection.x, moveDirection.y) * Mathf.Rad2Deg + _cameraTransform.eulerAngles.y;
            //float rotationAngle = Mathf.Atan2(moveDirection.x, moveDirection.y) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(_motorObject.eulerAngles.y, rotationAngle, ref _smoothVelocity, _smooth);

            _motorObject.rotation = Quaternion.Euler(0f, angle, 0f);
            Vector3 move = Quaternion.Euler(0f, rotationAngle, 0f) * Vector3.forward;

            _controller.Move(move.normalized * Model.Data.MoveSpeed * Time.deltaTime);
        }

        var groundedPlayer = _controller.isGrounded;
        if(groundedPlayer && _groundVelocity.y < 0f)
        {
            _groundVelocity.y = 0f;
        }
        _groundVelocity.y += -9.81f * Time.deltaTime;
        _controller.Move(_groundVelocity * Time.deltaTime);

    }
}
