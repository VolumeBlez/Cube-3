using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StormDayState : IDayTimeState
{
    private readonly DayTimeStateMachine _stateMachine;

    public StormDayState(DayTimeStateMachine stateMachine)
    {
        _stateMachine = stateMachine;
    }

    public void Enter()
    {
        _stateMachine.Settings.SetDayMode();
        _stateMachine.Settings.EnableLightFog();
    }

    public void Exit()
    {
    }
}
