using UnityEngine;
using Zenject;

public class ChangeTimeTrigger : MonoBehaviour
{
    [SerializeField] private float _changeTimeCoolDown;
    private Timer _timer;
    private bool _isChangeTimeAbilityActive = false;

    [Inject]
    private DayTimeStateMachine _machine;

    private void Start()
    {
        _machine.EnterIn<ClearNightState>();
        
        _timer = new();
        _timer.Start(_changeTimeCoolDown);
        _timer.TimerStop += () => _isChangeTimeAbilityActive = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(_isChangeTimeAbilityActive)
        {
            EnterInRandomDayState();
        }
    }

    [ContextMenu("Enter In Random DayState")]
    public void EnterInRandomDayState()
    {
        _machine.EnterInRandomState();
        _isChangeTimeAbilityActive = false;
        _timer.Start(_changeTimeCoolDown);
    }
}
