using System;
using UnityEngine;

[Serializable]
public class PlayerData
{
    [field: SerializeField] public Rigidbody Controller { get; private set; }
    [field: SerializeField] public Transform MotorObject { get; private set; }
    [field: SerializeField] public Transform GroundCheckObject { get; private set; }
    [field: SerializeField] public Camera Camera { get; private set; }
    [field: SerializeField] public AudioSource AudioSource { get; private set; }
    

    [field: SerializeField] public float MouseSens { get; private set;}
    [field: SerializeField] public float MoveSpeed { get; private set;}
    [field: SerializeField] public float GravityScale { get; private set;} // -9.81f
    [field: SerializeField] public float JumpHeight { get; private set;}
    [field: SerializeField] public float AllowGroundDistance { get; private set;} // 0.4f
    [field: SerializeField] public int StartMaxHealth { get; private set;}

}
