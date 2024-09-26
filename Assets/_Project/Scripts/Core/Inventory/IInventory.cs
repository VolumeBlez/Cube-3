public interface IInventory
{
    bool TryAdd(IItem item);
    bool TryRemove(ItemType itemType);
}
