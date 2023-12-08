using System;
using UnityEngine;
using Zenject;

public class InputHandler : IDisposable
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

    public InputHandler()
    {
        Input.Enable();
    }

    public void Dispose()
    {
        Input.Disable();
    }

    // public void Start()
    // {
    //     PlayerMoveView

    //     Input.Enable();

    //     Input.Gameplay.Movement.performed += ctx => _move.SetDirection(ctx.ReadValue<Vector2>());
    //     Input.Gameplay.Movement.canceled += ctx => _move.ResetDirection();

    //     Input.Gameplay.Interact.performed += ctx => _interact.PerformInteract();
    // }

    // public void OnEnable() 
    // {
    //     Input.Enable();
    // }

    // public void OnPauseGame()
    // {
    //     Input.Disable();
    // }
}
