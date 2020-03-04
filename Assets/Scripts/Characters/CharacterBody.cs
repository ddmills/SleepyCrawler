namespace Sleepy.Characters
{
    using System;
    using UnityEngine;

    [Serializable]
    public class CharacterBody : MonoBehaviour
    {
        [SerializeField]
        private BoxCollider2D _collider;
        public BoxCollider2D Collider { get { return _collider; }}

        private Character _character;
        public Character Character { get { return _character; }}

        private Vector2 _velocity;
        public Vector2 Velocity { get { return _velocity; }}
        private bool _isDashing;
        public Vector2 IsDashing { get { return _isDashing; }}
        public Vector2 Position { get { return transform.position; }}

        public void AssignCharacter(Character character)
        {
            _character = character;
        }

        public void SetVelocity(Vector2 velocity)
        {
            _velocity = velocity;
        }

        public void Dash()
        {
            _isDashing = true;
        }

        public void FixedUpdate()
        {
            if (!Character.IsController)
            {
                return;
            }

            Vector2 position = Position + Velocity * Time.fixedDeltaTime;
            Vector2 offset = ComputePhysicsOffest(position);

            transform.position = offset;
        }

        private Vector2 ComputePhysicsOffest(Vector2 targetPosition)
        {
            Vector2 result = targetPosition;
            Collider2D[] collisions = GetCollisions(targetPosition);

            foreach (Collider2D collision in collisions)
            {
                if (collision == Collider)
                {
                    continue;
                }

                ColliderDistance2D distance = collision.Distance(Collider);

                if (distance.isOverlapped)
                {
                    result = result + distance.pointA - distance.pointB;
                }
            }

            return result;
        }

        private Collider2D[] GetCollisions(Vector2 position)
        {
            return Physics2D.OverlapBoxAll(position, Collider.size, 0);
        }
    }
}
