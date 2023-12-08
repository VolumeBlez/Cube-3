using Cinemachine;
using UnityEngine;
using Zenject;

public class CameraTargetHandler : MonoBehaviour
{
    [SerializeField] private CinemachineFreeLook _camera;

    [Inject]
    private PlayerIndicator _player;
    void Start()
    {
        _camera.Follow = _player.transform;
        _camera.LookAt = _player.transform;
    }


}
