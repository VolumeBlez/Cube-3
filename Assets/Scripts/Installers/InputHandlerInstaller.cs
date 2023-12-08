using Zenject;

public class InputHandlerInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<InputHandler>().FromNew().AsSingle().NonLazy();
    }
}
