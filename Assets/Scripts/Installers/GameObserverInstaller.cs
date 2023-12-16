using Zenject;

public class GameObserverInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<GameObserver>().FromNew().AsSingle().NonLazy();
    }
}