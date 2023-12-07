using System;
using UnityEngine;


public class PlayerDieService : BasePlayerService
{
    public Action Die;

    private readonly PlayerAudioService _audioService;
    public PlayerDieService(IPlayerModel model, IPlayerPresenter presenter) : base(model, presenter)
    {
        _audioService = Presenter.GetService<PlayerAudioService>();
    }

    public void PlayerDie()
    {
        Model.Data.MotorObject.rotation = Quaternion.Euler(0, 0, 55f);
        _audioService.PlayDieSound();
        Die?.Invoke();
    }
}
