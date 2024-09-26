using DG.Tweening;
using UnityEngine;

public class ObstacleDamageable : MonoBehaviour, IDamageable
{
    public void ApplyDamage(int value = 1)
    {
        gameObject.isStatic = false;
        transform.DOShakeScale(1f, 1, 10);
    }
}
