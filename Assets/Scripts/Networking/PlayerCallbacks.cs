namespace Sleepy.Networking
{
    [BoltGlobalBehaviour("Test")]
    public class TutorialPlayerCallbacks : Bolt.GlobalEventListener
    {
        private BoltEntity entity;

        public override void SceneLoadLocalDone(string map)
        {
            entity = BoltNetwork.Instantiate(BoltPrefabs.PlayerCharacter);
            PlayerCamera.Instantiate();
            PlayerCamera.instance.SetTarget(entity.transform);
        }
    }
}
