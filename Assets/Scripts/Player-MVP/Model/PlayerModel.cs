public class PlayerModel : IPlayerModel
{
    public PlayerData Data { get; }
    public IInventory Inventory { get; }
    public PlayerAudioClipsData AudioClips { get; }

    public PlayerModel(PlayerData data, PlayerAudioClipsData clips)
    {
        Data = data;
        AudioClips = clips;

        Inventory = new Inventory();
    }
}
