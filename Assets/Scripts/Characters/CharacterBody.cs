namespace Sleepy.Characters
{
    using System;
    using System.Collections.Generic;
    using UnityEngine;

    [Serializable]
    public class CharacterBody : CharacterComponent
    {
        [SerializeField]
        private BoxCollider2D _collider;
        public BoxCollider2D Collider { get { return _collider; }}

        private float _speedControlThreshold = 3;
        private float _velocityLerpFactor = 5;

        private Vector2 _velocity;
        public Vector2 Velocity { get { return _velocity; }}
        private Vector2 _desiredVelocity;
        public Vector2 DesiredVelocity { get { return _desiredVelocity; }}
        private Vector2 _direction;
        public Vector2 Direction { get { return _direction; }}
        private List<Vector2> _impulses = new List<Vector2>();
        public IEnumerable<Vector2> Impulses { get { return _impulses; }}

        public Vector2 MovementDirection { get { return Speed > 0 ? Velocity.normalized : Direction; }}
        public float Angle { get { return (Mathf.Atan2(Direction.y, Direction.x) * Mathf.Rad2Deg) + 90; }}
        public Transform Transform { get { return transform; }}
        public Vector2 Position { get { return Transform.position; }}
        public float Speed { get { return Velocity.magnitude; }}

        public void SetVelocity(Vector2 velocity)
        {
            _velocity = velocity;
        }

        public void SetDesiredVelocity(Vector2 velocity)
        {
            _desiredVelocity = velocity;
        }

        public void SetDirection(Vector2 direction)
        {
            _direction = direction;
        }

        public void MoveToward(Vector2 position, float speed)
        {
            SetDesiredVelocity(GetNormalizedDirectionTo(position) * speed);
        }

        public void MoveAway(Vector2 position, float speed)
        {
            SetDesiredVelocity(GetNormalizedDirectionTo(position) * -speed);
        }

        public void LookAt(Vector2 position)
        {
            SetDirection(GetNormalizedDirectionTo(position));
        }

        public void AddImpulse(Vector2 impulse)
        {
            _impulses.Add(impulse);
        }

        public void Dash()
        {
            AddImpulse(MovementDirection * 10);
        }

        public void Knockback(Vector2 source, float amount)
        {
            AddImpulse(GetNormalizedDirectionTo(source) * -amount);
        }

        public void FixedUpdate()
        {
            if (!Character.IsController)
            {
                return;
            }

            _velocity = CalculateVelocity();

            Vector2 position = Position;
            position += Velocity * Time.fixedDeltaTime;

            transform.position = ComputePhysicsOffest(position);
        }

        private Vector2 CalculateVelocity()
        {
            Vector2 result = Velocity;
            foreach (Vector2 impulse in Impulses)
            {
                result += impulse;
            }
            result = Vector2.Lerp(result, _desiredVelocity, Time.fixedDeltaTime * _velocityLerpFactor);
            _impulses.Clear();

            if (result.magnitude < _speedControlThreshold && _desiredVelocity.magnitude < _speedControlThreshold)
            {
                return _desiredVelocity;
            }

            return result;
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
                    SetVelocity(Vector2.zero);
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

        public Vector2 GetNormalizedDirectionTo(Vector2 position)
        {
            return (position - Position).normalized;
        }

        public float GetDistanceTo(Vector2 position)
        {
            return Vector2.Distance(Position, position);
        }
    }
}
