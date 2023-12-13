public interface IPlayerPresenter
{
    IPlayerModel Model { get; }

    IPlayerPresenter RegisterService(BasePlayerService service);
    T GetService<T>() where T : BasePlayerService;
}
