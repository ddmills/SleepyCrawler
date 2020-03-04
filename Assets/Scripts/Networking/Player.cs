namespace Sleepy.Networking
{
    public class Player
    {
        private BoltConnection _connection;
        public BoltConnection Connection { get { return _connection; }}
        public bool IsServer { get { return Connection == null; }}
        public bool IsClient { get { return Connection != null; }}

        public Player(BoltConnection connection)
        {
            _connection = connection;

            if (Connection != null)
            {
                Connection.UserData = this;
            }
        }
    }
}
