namespace Sleepy.Characters.AI
{
    public class IdleBehavior : IBehavior
    {
        public void Behave(Character character) {
            character.Controller.Stop();
        }
    }
}
