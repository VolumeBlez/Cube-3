using System;
using UnityEngine;

//[CreateAssetMenu(fileName = "Inventory Item")]
//public class Item : ScriptableObject, IItem

[Serializable]
public class Item : IItem
{
    [SerializeField] private ItemType _type;
    private int _count = 1;

    // public Item(ItemType type, int startCount = 1)
    // {
    //     _type = type;
    //     _count = startCount;
    // }

    public ItemType Type => _type;
    public int Count => _count;

    public void DecreaseCount()
    {
        _count--;
    }

    public void IncreaseCount()
    {
        _count++;
    }
}
