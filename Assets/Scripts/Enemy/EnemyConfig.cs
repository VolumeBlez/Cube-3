using UnityEngine;

[CreateAssetMenu(fileName = "Enemy Config")]
public class EnemyConfig : ScriptableObject
{
    [field: SerializeField] public LayerMask WhatIsPlayer { get; private set; }
    [field: SerializeField] public float SightRange { get; private set; }
    [field: SerializeField] public float AttackRange { get; private set; }
    [field: SerializeField] public float WalkPointRange { get; private set; }

    [field: SerializeField] public int Damage { get; private set; }
    [field: SerializeField] public int AttackCoolDown { get; private set; }
    
}
