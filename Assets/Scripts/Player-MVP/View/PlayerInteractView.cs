using Zenject;

public class PlayerInteractView : BasePlayerView
{
    [Inject]
    private InputHandler _handler;
    private PlayerRayService _interactService;
    public override void InitView(IPlayerPresenter presenter)
    {
        base.InitView(presenter);
        _interactService = Presenter.GetService<PlayerRayService>();

        _handler.Input.Gameplay.Interact.performed += ctx => PerformInteract();
    }

    public void PerformInteract()
    {
        _interactService.PerformRay();
    }

}
