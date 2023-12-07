public class PlayerInteractView : BasePlayerView
{
    private PlayerRayService _interactService;
    public override void InitView(IPlayerPresenter presenter)
    {
        base.InitView(presenter);
        _interactService = Presenter.GetService<PlayerRayService>();
    }

    public void PerformInteract()
    {
        _interactService.PerformRay();
    }
}
