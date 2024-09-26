public class InputHandler 
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
}
