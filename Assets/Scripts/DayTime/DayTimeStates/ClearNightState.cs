using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearNightState : IDayTimeState
{
    private readonly DayTimeStateMachine _stateMachine;

    public ClearNightState(DayTimeStateMachine stateMachine)
    {
        _stateMachine = stateMachine;
    }

    public void Enter()
    {
        _stateMachine.Settings.SetNight();
        _stateMachine.Settings.ClearSky();
    }

    public void Exit()
    {
    }
}
