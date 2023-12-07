public abstract class BasePlayerService
{
    protected readonly IPlayerModel Model;
    protected readonly IPlayerPresenter Presenter;

    protected BasePlayerService(IPlayerModel model, IPlayerPresenter presenter)
    {
        Model = model;
        Presenter = presenter;
    }
}
