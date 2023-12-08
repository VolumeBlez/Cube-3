using System;
using UnityEngine;

[Serializable]
public class PlayerData
{
    [field: SerializeField] public CharacterController Controller { get; private set; }
    [field: SerializeField] public Transform MotorObject { get; private set; }
    [field: SerializeField] public AudioSource AudioSource { get; private set; }
    

    [field: SerializeField] public float MouseSens { get; private set;}
    [field: SerializeField] public float RotateSmooth { get; private set;}
    [field: SerializeField] public float MoveSpeed { get; private set;}
    [field: SerializeField] public int StartMaxHealth { get; private set;}

}
