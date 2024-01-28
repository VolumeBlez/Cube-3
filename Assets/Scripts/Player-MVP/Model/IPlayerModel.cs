public interface IPlayerModel 
{
    PlayerData Data { get; }
    IInventory Inventory { get; }
    ReactiveProperty Health { get; }
    ReactiveProperty Freezing { get; }
    PlayerAudioClipsData AudioClips { get; }
}