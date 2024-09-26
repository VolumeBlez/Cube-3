using UnityEngine;

namespace VB
{
    public interface IPlayerModel
    {
        public IntValueProperty Health { get; }
        public IntValueProperty Freezing { get; }
        public IInventory Inventory { get; }
        public Vector3 CurrentPosition { get; }
        public PlayerData Data { get; }
        public PlayerAudioClipsData AudioClips { get; }

    }
}
