using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerRayService : BasePlayerService
{
    public PlayerRayService(IPlayerModel model, IPlayerPresenter presenter) : base(model, presenter)
    {
    }

    public void PerformRay()
    {
        Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
        RaycastHit hit;

        //Debug.DrawRay(Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue()), Camera, Color.green, 2f);
        //Debug.DrawRay(Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue()), Camera.main.transform.forward * 50f, Color.green, 2f);
        if(Physics.Raycast(ray, out hit, 50f))
        {
            if(hit.transform.TryGetComponent(out ItemView itemView))
            {
                Presenter.Model.Inventory.TryAdd(itemView.Item);
                itemView.DestroyItemView();
            }
        }
    }
}
