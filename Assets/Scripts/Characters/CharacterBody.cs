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

        private Vector2 _previousPosition;
        private Vector2 _velocity;
        public Vector2 Velocity { get { return _velocity; }}
        public float Speed { get { return Velocity.magnitude; }}
        public Vector2 Direction { get { return (Position - _previousPosition).normalized; }}
        private bool _isDashing;
        public bool IsDashing { get { return _isDashing; }}
        public Vector2 Position { get { return transform.position; }}

        void Awake()
        {
            _previousPosition = Position;
        }

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

            Vector2 offset = ComputePhysicsOffest(position);

            if (offset != Position)
            {
                _previousPosition = Position;
            }
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
