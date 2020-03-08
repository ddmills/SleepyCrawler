namespace Sleepy.Networking
{
    using Bolt;
    using UnityEngine;

    [BoltGlobalBehaviour(BoltNetworkModes.Server, "Test")]
    public class ServerCallbacks : GlobalEventListener
    {
        void Awake()
        {
            BoltNetwork.Instantiate(BoltPrefabs.Block, new Vector3(0, 1, 0), Quaternion.identity);
            BoltNetwork.Instantiate(BoltPrefabs.Block, new Vector3(1, 1, 0), Quaternion.identity);
            BoltNetwork.Instantiate(BoltPrefabs.Block, new Vector3(2, 1, 0), Quaternion.identity);
            BoltNetwork.Instantiate(BoltPrefabs.OtherCharacter, new Vector3(1, 5, 0), Quaternion.identity);
            PlayerRegistry.CreateServerPlayer();
        }

        public override void Connected(BoltConnection connection)
        {
            PlayerRegistry.CreateClientPlayer(connection);
        }
    }
}
