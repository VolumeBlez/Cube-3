using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class DayTimeStateMachineInstaller : MonoInstaller
{
    [Inject]
    private SceneRenderSettings _settings;
    public override void InstallBindings()
    {
        Container.Bind<DayTimeStateMachine>().FromNew().AsSingle().WithArguments(_settings).NonLazy();
    }
}
