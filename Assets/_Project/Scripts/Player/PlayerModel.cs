using UnityEngine;

namespace VB
{
    public class PlayerModel : IPlayerModel
    {
        public IInventory Inventory { get; private set; }
        public Vector3 CurrentPosition { get; private set; }
        public PlayerData Data { get; private set; }
        public PlayerAudioClipsData AudioClips { get; private set; }
        public IntValueProperty Health { get; private set; }
        public IntValueProperty Freezing { get; private set; }

        public PlayerModel(PlayerData data, PlayerAudioClipsData clips)
        {
            Data = data;
            AudioClips = clips;

            Inventory = new Inventory();
            Health = new IntValueProperty(100);
            Freezing = new IntValueProperty(100);
            CurrentPosition = Vector3.one;
        }

        public void UpdatePosition(Vector3 newPos)
        {
            CurrentPosition = newPos;
        }
    }
}
