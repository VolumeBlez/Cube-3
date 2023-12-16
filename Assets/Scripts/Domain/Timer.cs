using System;

public class Timer
{
    public Action TimerStop;

    private bool _isEnabled;

    public float Time { get; private set; }
    public float ElapsedTime { get; private set; }

    public void Update(float tick) 
    {
        if(_isEnabled == false) return;

        ElapsedTime += tick;

        if(ElapsedTime >= Time)
        {
            _isEnabled = false;
            TimerStop?.Invoke();
        }
    }

    public void Start(float time) 
    {
        ElapsedTime = 0;
        Time = time;
        _isEnabled = true;
    }

    public void ForceStop()
    {
        _isEnabled = false;
    }

    public void Continue()
    {
        _isEnabled = true;
    }
}
