public interface IPlayerModel 
{
    PlayerData Data { get; }
    IInventory Inventory { get; }
    PlayerAudioClipsData AudioClips { get; }
}