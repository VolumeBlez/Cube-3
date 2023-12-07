using UnityEngine;

public class PlayerAudioService : BasePlayerService
{
    private readonly AudioSource _source;
    public PlayerAudioService(IPlayerModel model, IPlayerPresenter presenter, AudioSource source) : base(model, presenter)
    {
        _source = source;
    }

    public void PlayJumpSound()
    {
        if(_source == null) return;
        if(_source.isPlaying) return;

        _source.pitch = Random.Range(0.8f, 1.2f);
        _source.PlayOneShot(Model.AudioClips.JumpClip, 0.3f);
    }

    public void PlayDieSound()
    {
        if(_source == null) return;
        
        _source.pitch = Random.Range(0.8f, 1.2f);
        _source.Play();
        _source.loop = true;
    }
}
