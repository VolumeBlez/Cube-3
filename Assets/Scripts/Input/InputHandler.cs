public class InputHandler : IStartGameListener, IPauseGameListener, IResumeGameListener
{
    private Input _input;

    public Input Input 
    {
        get 
        {
            if(_input != null) return _input;
            return _input = new Input();
        }
    }

    public void OnPauseGame()
    {
        Input.Gameplay.Disable();
    }

    public void OnResumeGame()
    {
        Input.Gameplay.Enable();
    }

    public void OnStartGame()
    {
        Input.Enable();
    }
}
