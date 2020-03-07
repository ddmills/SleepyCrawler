namespace Sleepy.Combat
{
    using System;
    using Bolt;

    [Serializable]
    public struct StrikeData
    {
        public string Type;
        public float Amount;
        public float Timestamp;
        public BoltEntity SourceEntity;

        public StrikeData(string type, float amount, BoltEntity sourceEntity, float timestamp)
        {
            Type = type;
            Amount = amount;
            SourceEntity = sourceEntity;
            Timestamp = timestamp;
        }

        public StrikeEvent ToBoltStrikeEvent(BoltEntity reciever)
        {
            StrikeEvent evnt = StrikeEvent.Create(reciever);

            evnt.Amount = Amount;
            evnt.Source = SourceEntity;
            evnt.Timestamp = Timestamp;
            evnt.Type = Type;

            return evnt;
        }
    }
}
