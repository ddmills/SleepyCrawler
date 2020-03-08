namespace Sleepy.Characters.AI
{
    public class MeleeAttackBehavior : IBehavior
    {
        private Character target;

        public MeleeAttackBehavior(Character other)
        {
            target = other;
        }

        public void Behave(Character character) {
            float distance = character.Body.GetDistanceTo(target.Position);

            character.Body.LookAt(target.Position);

            if (character.Combat.IsBasicAttackReady)
            {
                if (character.Combat.IsWithinBasicAttackRange(target.Position))
                {
                    character.Combat.BasicAttack();
                }
                else
                {
                    character.Controller.Follow(target, character.Combat.BasicAttackRange);
                }

            }
            else
            {
                character.Controller.Flee(target);
            }
        }
    }
}
