using UnityEngine;
using Zenject;

public class PlayerInstaller : MonoInstaller
{
    [SerializeField] private Transform _playerSpawnPoint;
    [SerializeField] private PlayerIndicator _playerPrefab;

    public override void InstallBindings()
    {
        PlayerIndicator player = Container
            .InstantiatePrefabForComponent<PlayerIndicator>(_playerPrefab, _playerSpawnPoint.position, Quaternion.identity, null);
    
        Container
            .Bind<PlayerIndicator>()
            .FromInstance(player)
            .AsSingle();
            // Non Lazy
    }
}
