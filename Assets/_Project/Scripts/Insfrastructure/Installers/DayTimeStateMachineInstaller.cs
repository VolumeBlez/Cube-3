using UnityEngine;
using VB;
using Zenject;

public class DayTimeStateMachineInstaller : MonoInstaller
{
    [SerializeField] private EnvironmentController _environmentController;

    public override void InstallBindings()
    {
        Container.Bind<EnvironmentController>().FromInstance(_environmentController)
            .AsSingle().NonLazy();

        Container.Bind<DayTimeStateMachine>().FromNew()
            .AsSingle().NonLazy();
    }
}
