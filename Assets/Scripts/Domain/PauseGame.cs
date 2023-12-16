using UnityEngine;
using Zenject;

public class PauseGame : MonoBehaviour
{
    private GameObserver _observer;
    private bool _isPauseToSet = false;

    [Inject]
    public void InitPause(InputHandler handler, GameObserver observer)
    {
        _observer = observer;
        handler.Input.Settings.Pause.performed += ctx => SetPause();
    }

    private void SetPause()
    {
        _isPauseToSet = _isPauseToSet? false : true;

        if(_isPauseToSet)
            _observer.PauseGame();
        else
            _observer.ResumeGame();
    }

}
