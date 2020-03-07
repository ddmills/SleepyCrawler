namespace Sleepy.Characters.AI
{
    public class FleeBehavior : IBehavior
    {
        private Character target;

        public FleeBehavior(Character other)
        {
            target = other;
        }

        public void Behave(Character character) {
            character.Controller.Flee(target);
        }
    }
}
