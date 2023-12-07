using System;
using UnityEngine;

[Serializable]
public class PlayerAudioClipsData
{
    [field: SerializeField] public AudioClip DieClip { get; private set; }
    [field: SerializeField] public AudioClip JumpClip { get; private set; }
}
