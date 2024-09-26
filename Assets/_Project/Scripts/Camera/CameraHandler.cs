using Cinemachine;
using UnityEngine;
using VB;
using Zenject;

public class CameraHandler : MonoBehaviour, IPauseGameListener, IResumeGameListener
{
    [SerializeField] private CinemachineFreeLook _camera;

    public void OnPauseGame()
    {
        _camera.enabled = false;
    }

    public void OnResumeGame()
    {
        _camera.enabled = true;
    }

    [Inject]
    void Init(PlayerIndicator _player, GameObserver observer)
    {
        _camera.Follow = _player.transform;
        _camera.LookAt = _player.transform;

        observer.AddListener(this);
    }



}
