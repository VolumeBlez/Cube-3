public interface IItem
{
    ItemType Type { get; }
    int Count { get; }

    void IncreaseCount();
    void DecreaseCount();
}
