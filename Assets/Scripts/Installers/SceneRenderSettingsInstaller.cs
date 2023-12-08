using UnityEngine;
using Zenject;

public class SceneRenderSettingsInstaller : MonoInstaller
{
    [SerializeField] private SceneRenderSettings _sceneRenderSettings;
    public override void InstallBindings()
    {
        Container
            .Bind<SceneRenderSettings>()
            .FromInstance(_sceneRenderSettings)
            .AsSingle().NonLazy();
    }
}
