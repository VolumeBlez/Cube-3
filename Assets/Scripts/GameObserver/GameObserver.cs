using System.Collections.Generic;

public sealed class GameObserver
{
    private readonly List<object> listeners = new();

    public void StartGame()
    {
        foreach (var listener in listeners)
        {
            if (listener is IStartGameListener startListener)
            {
                startListener.OnStartGame();
            }
        }
    }

    public void PauseGame()
    {
        foreach (var listener in listeners)
        {
            if (listener is IPauseGameListener pauseListener)
            {
                pauseListener.OnPauseGame();
            }
        }
    }

    public void ResumeGame()
    {
        foreach (var listener in listeners)
        {
            if (listener is IResumeGameListener pauseListener)
            {
                pauseListener.OnResumeGame();
            }
        }
    }

    public void AddListener(object listener)
    {
        listeners.Add(listener);
    }

    public void RemoveListener(object listener)
    {
        listeners.Remove(listener);
    }
}
