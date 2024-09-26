using UnityEngine;
using Zenject;

public class EnemyStateMachineInstaller : MonoInstaller
{
    [SerializeField] private EnemyStateMachine _enemy;
    public override void InstallBindings()
    {
        Container
            .Bind<EnemyStateMachine>()
            .FromInstance(_enemy)
            .AsSingle();
    }
}