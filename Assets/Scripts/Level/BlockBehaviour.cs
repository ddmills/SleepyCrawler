namespace Sleepy.Level
{
    using Bolt;

    public class BlockBehaviour : EntityEventListener<IBlockState> {
        public override void OnEvent(StrikeEvent evnt)
        {
            BoltConsole.Write("Block received strike " + evnt.Amount + " of " + evnt.Type + " by " + evnt.Source.name);
        }
    }
}
