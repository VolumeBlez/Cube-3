using System;

public class EndLevelEventBus
{
    private Action GameWin;
    private Action GameLost;

    private bool _isGameEnd = false;

    public void InvokeWinAction()
    {
        if(_isGameEnd == false)
        {
            GameWin?.Invoke();
            _isGameEnd = true;
        }
    }

    public void InvokeLostAction()
    {
        if(_isGameEnd == false)
        {
            GameLost?.Invoke();
            _isGameEnd = true;
        }
    }

    public void Subscribe(IEndLevelEventHandler eventHandler)
    {
        GameWin += eventHandler.OnWinGame;
        GameLost += eventHandler.OnLooseGame;
    }

}
