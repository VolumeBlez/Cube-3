using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StormyNightState : IDayTimeState
{
    private readonly DayTimeStateMachine _stateMachine;

    public StormyNightState(DayTimeStateMachine stateMachine)
    {
        _stateMachine = stateMachine;
    }

    public void Enter()
    {
        _stateMachine.Settings.SetNight();
        _stateMachine.Settings.DarkFog();
    }

    public void Exit()
    {
    }
}
