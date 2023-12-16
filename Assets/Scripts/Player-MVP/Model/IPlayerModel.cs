public interface IPlayerModel 
{
    PlayerData Data { get; }
    IInventory Inventory { get; }
    Health Health { get; }
    PlayerAudioClipsData AudioClips { get; }
}