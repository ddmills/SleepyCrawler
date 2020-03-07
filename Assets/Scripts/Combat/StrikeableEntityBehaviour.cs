namespace Sleepy.Combat
{
    using Bolt;

    public class StrikeableEntityBehaviour : EntityBehaviour {
        public void TriggerBoltStrikeEvent(StrikeData strike)
        {
            strike.ToBoltStrikeEvent(entity).Send();
        }
    }
}
