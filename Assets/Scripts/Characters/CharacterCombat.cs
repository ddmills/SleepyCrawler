namespace Sleepy.Characters
{
    using Combat;
    using UnityEngine;

    public class CharacterCombat : CharacterComponent
    {
        private float _startAttackTime = 0;
        public bool IsBasicAttackReady { get { return _startAttackTime + Character.Inventory.Weapon.AttackCooldownDuration <= Time.time; }}
        public float BasicAttackRange { get { return Character.Inventory.Weapon.ColliderSize.y + Character.Inventory.Weapon.ColliderOffset; }}

        public bool IsWithinBasicAttackRange(Vector2 position)
        {
            return BasicAttackRange >= Character.Body.GetDistanceTo(position);
        }

        public bool BasicAttack()
        {
            if (!IsBasicAttackReady)
            {
                return false;
            }

            float now = Time.time;

            Collider2D[] collisions = Character.Body.CastBoxInFront(
                Character.Inventory.Weapon.ColliderSize,
                Character.Inventory.Weapon.ColliderOffset
            );

            foreach (Collider2D collision in collisions)
            {
                if (collision == Character.Body.Collider)
                {
                    continue;
                }

                Strikeable strikeable = collision.gameObject.GetComponent<Strikeable>();

                if (strikeable)
                {
                    StrikeData strike = new StrikeData(
                        Character.Inventory.Weapon.StrikeType,
                        100,
                        Character.Entity,
                        now
                    );

                    strikeable.Strike(strike);
                }
            }

            Character.Animator.SetTrigger("SlashAttack");

            _startAttackTime = now;

            return true;
        }
    }
}
