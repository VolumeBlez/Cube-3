using UnityEngine;

public class PlayerRotateService : BasePlayerService
{
    public PlayerRotateService(IPlayerModel model, IPlayerPresenter presenter) : base(model, presenter)
    {
    }

    public void SetRotation(Vector2 rotation, ref float xRotation)
    {
        rotation = rotation * Model.Data.MouseSens * Time.deltaTime;

        xRotation -= rotation.y;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        Model.Data.Camera.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        Model.Data.MotorObject.Rotate(Vector3.up * rotation.x);
    }
}
