namespace Sleepy.Characters.AI
{
    public class FollowBehavior : IBehavior
    {
        private Character target;

        public FollowBehavior(Character other)
        {
            target = other;
        }

        public void Behave(Character character) {
            character.Controller.Follow(target, 2f);
        }
    }
}
