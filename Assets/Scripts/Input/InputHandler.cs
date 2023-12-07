using UnityEngine;

public class InputHandler : MonoBehaviour
{
    [SerializeField] private PlayerMoveView _move;
    [SerializeField] private PlayerRotateView _rotate;
    [SerializeField] private PlayerInteractView _interact;

    private Input _input;

    public Input Input 
    {
        get 
        {
            if(_input != null) return _input;
            return _input = new Input();
        }
    }

    public void Start()
    {
        Input.Enable();

        Input.Gameplay.Movement.performed += ctx => _move.SetDirection(ctx.ReadValue<Vector2>());
        Input.Gameplay.Movement.canceled += ctx => _move.ResetDirection();

        Input.Gameplay.Look.performed += ctx => _rotate.SetDirection(ctx.ReadValue<Vector2>());

        Input.Gameplay.Interact.performed += ctx => _interact.PerformInteract();
    }

    public void OnPauseGame()
    {
        Input.Disable();
    }
}
