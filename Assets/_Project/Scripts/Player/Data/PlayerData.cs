using UnityEngine;

namespace VB
{
    [CreateAssetMenu(fileName = "Player Data")]
    public class PlayerData : ScriptableObject
    {
        [field: SerializeField] public float MouseSens { get; private set;} = 13f;
        [field: SerializeField] public float RotateSmooth { get; private set;} = 0.15f;
        [field: SerializeField] public float MoveSpeed { get; private set;} = 5f;
        [field: SerializeField] public int StartMaxHealth { get; private set;} = 100;
    }
}
