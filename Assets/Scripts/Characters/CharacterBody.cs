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
        private Vector2 _direction;
        public Vector2 Direction { get { return _direction; }}
        public float Angle { get { return (Mathf.Atan2(Direction.y, Direction.x) * Mathf.Rad2Deg) + 90; }}
        private bool _isDashing;
        public bool IsDashing { get { return _isDashing; }}
        public Vector2 Position { get { return transform.position; }}
        public float Speed { get { return Velocity.magnitude; }}

        public void AssignCharacter(Character character)
        {
            _character = character;
        }

        public void SetVelocity(Vector2 velocity)
        {
            _velocity = velocity;
        }

        public void SetDirection(Vector2 direction)
        {
            _direction = direction;
        }

        public void LookAt(Vector2 point)
        {
            SetDirection((point - Position).normalized);
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

            Vector2 position = Position;
            position += Velocity * Time.fixedDeltaTime;

            if (IsDashing)
            {
                RaycastHit2D hit = Physics2D.Raycast(Position, Direction, 1);
                if (hit.collider != null)
                {
                    position = hit.point;
                }
                else
                {
                    position += Direction * 1;
                }
                _isDashing = false;
            }

            transform.position = ComputePhysicsOffest(position);
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

        public Collider2D[] CastBoxInFront(Vector2 size, float offset)
        {
            return Physics2D.OverlapBoxAll(
                Position + (
                    Direction * ((size.y / 2) + offset)
                ),
                size,
                Angle
            );
        }
    }
}
