using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerRayService : BasePlayerService
{
    public PlayerRayService(IPlayerModel model, IPlayerPresenter presenter) : base(model, presenter)
    {
    }

    public void PerformRay()
    {
        // Ray ray = Model.Data.Camera.ScreenPointToRay(Mouse.current.position.ReadValue());

        // if(Physics.Raycast(ray, out RaycastHit hit, 10f))
        // {
            
        // }
    }
}
