namespace Sleepy.Characters
{
    using Combat;
    using UnityEngine;

    public class CharacterCombat : CharacterComponent
    {
        private float _startAttackTime = 0;
        public bool IsBasicAttackReady { get { return _startAttackTime + Character.Inventory.Item.CooldownDuration <= Time.time; }}
        public float BasicAttackRange { get { return Character.Inventory.Item.AttackType.Range(Character); }}

        public bool IsWithinBasicAttackRange(Vector2 position)
        {
            return BasicAttackRange >= Character.Body.GetDistanceTo(position);
        }

        public bool BasicAttack()
        {
            // if (!IsBasicAttackReady)
            // {
            //     return false;
            // }

            Character.Inventory.UsePrimary();

            _startAttackTime = Time.time; // TODO move to individual item instance (?)

            return true;
        }
    }
}
