using UnityEngine;

public class PlayerMoveView : BasePlayerView
{
    private Transform _movableObject;
    private Vector3 _newDirection;
    private Vector3 _currentMoveDirection;
    private PlayerMoveService _moveService;

    public override void InitView(IPlayerPresenter presenter)
    {
        base.InitView(presenter);
        _moveService = Presenter.GetService<PlayerMoveService>();
        _movableObject = presenter.Model.Data.MotorObject;
    }

    private void Update() 
    {
        if(!IsInitialized) return;
        _currentMoveDirection = _movableObject.right * _newDirection.x + _movableObject.forward * _newDirection.y;
        _currentMoveDirection = _currentMoveDirection.normalized * Time.deltaTime;

        if(_currentMoveDirection != _newDirection)
        {
            _moveService.SetMove(_currentMoveDirection);
        }
    }

    public void SetDirection(Vector2 direction) => _newDirection = direction;

    public void ResetDirection() => _newDirection = Vector3.zero; 
}
