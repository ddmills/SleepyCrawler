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

        private bool started = false;

        void Start()
        {
            started = true;
        }

        void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            if (started)
            {
                Gizmos.DrawWireCube(Character.Body.Position, transform.localScale);
                Matrix4x4 rot = Matrix4x4.TRS(
                    Character.Body.Position,
                    Quaternion.Euler(0, 0, Character.Body.Angle),
                    Vector3.one
                );

                Gizmos.matrix = rot;
                Gizmos.DrawWireCube(
                    new Vector2(0, -Character.Inventory.Weapon.ColliderSize.y / 2) - (new Vector2(0, Character.Inventory.Weapon.ColliderOffset)),
                    Character.Inventory.Weapon.ColliderSize
                );
            }
        }
    }
}
