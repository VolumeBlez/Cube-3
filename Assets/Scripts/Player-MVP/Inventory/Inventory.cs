using System.Collections.Generic;
using UnityEngine;


public class Inventory : IInventory
{
    private List<IItem> _items;

    public Inventory()
    {
        _items = new();
    }

    public bool TryAdd(IItem item)
    {
        for (int i = 0; i < _items.Count; i++)
        {
            if(_items[i].Type == item.Type) //_items[i].Type == item.Type
            {
                _items[i].IncreaseCount();
                Debug.Log(_items[i].Count);
                return true;
            }
        }

        _items.Add(item);
        return true;
    }

    public bool TryRemove(ItemType itemType)
    {
        for (int i = 0; i < _items.Count; i++)
        {
            if(_items[i].Type == itemType)
            {
                if(_items[i].Count > 1)
                    _items[i].DecreaseCount();
                else
                    _items.Remove(_items[i]);

                return true;
            }
        }

        return false;
    }
}
