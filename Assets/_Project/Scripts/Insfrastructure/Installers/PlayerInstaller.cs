using UnityEngine;
using VB;
using Zenject;

public class PlayerInstaller : MonoInstaller
{
    [SerializeField] private Transform _playerSpawnPoint;
    [SerializeField] private GameObject _playerPrefab;

    [Header("Player Datas")]
    [SerializeField] private PlayerAudioClipsData _audioClips;
    [SerializeField] private PlayerData _data;

    public override void InstallBindings()
    { 
        PlayerModel model = new PlayerModel(_data, _audioClips);
        PlayerController controller = new PlayerController(model);

        Container.BindInterfacesAndSelfTo<PlayerModel>().FromInstance(model).AsSingle();
        Container.Bind<PlayerController>().FromInstance(controller).AsSingle();

        PlayerIndicator playerIndicator = Container.InstantiatePrefabForComponent<PlayerIndicator>(_playerPrefab, _playerSpawnPoint);
        Container.Bind<PlayerIndicator>().FromInstance(playerIndicator).AsSingle();
    }
}
