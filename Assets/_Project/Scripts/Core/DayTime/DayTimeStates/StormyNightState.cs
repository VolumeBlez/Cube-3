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
        _stateMachine.Settings.SetNightMode();
        _stateMachine.Settings.EnableDarkFog();
    }

    public void Exit()
    {
    }
}
