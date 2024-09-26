using UnityEngine;

public class ItemView : MonoBehaviour
{
    [field: SerializeField] public Item Item { get; private set; }

    public void DestroyItemView()
    {
        Destroy(gameObject);
    }
}
