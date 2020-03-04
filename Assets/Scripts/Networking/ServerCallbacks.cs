namespace Sleepy.Networking
{
    using Bolt;

    [BoltGlobalBehaviour(BoltNetworkModes.Server, "Test")]
    public class ServerCallbacks : GlobalEventListener
    {
        void Awake()
        {
            PlayerRegistry.CreateServerPlayer();
        }

        public override void Connected(BoltConnection connection)
        {
            PlayerRegistry.CreateClientPlayer(connection);
        }
    }
}
