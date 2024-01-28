public class PlayerModel : IPlayerModel
{
    public PlayerData Data { get; }
    public IInventory Inventory { get; }
    public ReactiveProperty Health { get; }
    public ReactiveProperty Freezing { get; }
    public PlayerAudioClipsData AudioClips { get; }

    public PlayerModel(PlayerData data, PlayerAudioClipsData clips)
    {
        Data = data;
        AudioClips = clips;

        Inventory = new Inventory();
        Health = new ReactiveProperty(100);
        Freezing = new ReactiveProperty(100);
    }
}
