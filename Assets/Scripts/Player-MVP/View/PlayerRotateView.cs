using UnityEngine;

public class PlayerRotateView : BasePlayerView
{
    private float _xRotation;
    private PlayerRotateService _rotateService;
    
    public override void InitView(IPlayerPresenter presenter)
    {
        base.InitView(presenter);
        _rotateService = Presenter.GetService<PlayerRotateService>();

        Cursor.lockState = CursorLockMode.Locked;
    }

    public void SetDirection(Vector2 direction) => _rotateService.SetRotation(direction, ref _xRotation);
}
