using UnityEngine;

public class PlayerMoveService : BasePlayerService
{
    private readonly Rigidbody _rb;
    public PlayerMoveService(IPlayerModel model, IPlayerPresenter presenter) : base(model, presenter)
    {
        _rb = Model.Data.Controller;
    }

    public void SetMove(Vector3 moveDirection)
    {
        //Model.Data.Controller.Move(moveDirection * Model.Data.MoveSpeed);
        _rb.MovePosition(moveDirection * Model.Data.MoveSpeed);
    }
}
