namespace Sleepy.Networking
{
    using System.Collections.Generic;

    public static class PlayerRegistry
    {
        static private List<Player> _players = new List<Player>();
        static public IEnumerable<Player> Players { get { return _players; }}
        public static Player ServerPlayer
        {
            get { return _players.Find(player => player.IsServer); }
        }

        static Player CreatePlayer(BoltConnection connection)
        {
            Player player = new Player(connection);

            _players.Add(player);

            return player;
        }

        public static Player GetPlayer(BoltConnection connection)
        {
            if (connection == null)
            {
                return ServerPlayer;
            }

            return (Player) connection.UserData;
        }

        public static Player CreateServerPlayer()
        {
            return CreatePlayer(null);
        }

        public static Player CreateClientPlayer(BoltConnection connection)
        {
            return CreatePlayer(connection);
        }
    }
}
