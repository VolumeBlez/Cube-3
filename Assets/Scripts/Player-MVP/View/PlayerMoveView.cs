using UnityEngine;
using Zenject;

public class PlayerMoveView : BasePlayerView
{
    [Inject]
    private InputHandler _handler;

    private Vector3 _newDirection;
    private PlayerMotorService _moveService;

    public override void InitView(IPlayerPresenter presenter)
    {
        base.InitView(presenter);
        _moveService = Presenter.GetService<PlayerMotorService>();

        _handler.Input.Gameplay.Movement.performed += ctx => SetDirection(ctx.ReadValue<Vector2>());
        _handler.Input.Gameplay.Movement.canceled += ctx => ResetDirection();
    }

    private void Update() 
    {
        if(!IsInitialized) return;
        _moveService.SetMove(_newDirection);
    }

    public void SetDirection(Vector2 direction) => _newDirection = direction;

    public void ResetDirection() => _newDirection = Vector3.zero; 
}
