namespace Sleepy.Characters
{
    using UnityEngine;

    public class CharacterController : CharacterComponent
    {
        public enum MoveMode {
            NONE,
            GO_TO,
            FOLLOW,
            FLEE
        };

        private MoveMode _mode = MoveMode.NONE;
        public MoveMode Mode { get { return _mode; }}
        private Vector2 _targetPosition;
        public Vector2 TargetPosition { get { return _targetPosition; }}
        private Transform _targetTransform;
        public Transform TargetTransform { get { return _targetTransform; }}

        private float _walkSpeed = .5f;
        private float _runSpeed = 2;

        public void MoveTo(Vector3 position)
        {
            _mode = MoveMode.GO_TO;
            _targetPosition = position;
        }

        public void Follow(Transform transform)
        {
            _mode = MoveMode.FOLLOW;
            _targetTransform = transform;
        }

        public void Follow(Character other)
        {
            Follow(other.Transform);
        }

        public void Stop()
        {
            _mode = MoveMode.NONE;
        }

        public void Flee(Transform transform)
        {
            _mode = MoveMode.FLEE;
            _targetTransform = transform;
        }

        public void Flee(Character other)
        {
            Flee(other.Transform);
        }

        public void FixedUpdate()
        {
            if (Character.IsController)
            {
                switch (Mode)
                {
                    case MoveMode.GO_TO:
                        ModeGoTo();
                        break;
                    case MoveMode.FOLLOW:
                        ModeFollow();
                        break;
                    case MoveMode.FLEE:
                        ModeFlee();
                        break;
                    default:
                    case MoveMode.NONE:
                        ModeNone();
                        break;
                }
            }
        }

        private void ModeNone()
        {
        }

        private void ModeGoTo()
        {
            Character.Body.SetDesiredVelocity(
                GetNormalizedDirectionTo(TargetPosition) * -_walkSpeed
            );
        }

        private void ModeFlee()
        {
            Character.Body.SetDesiredVelocity(
                GetNormalizedDirectionTo(TargetTransform.position) * -_runSpeed
            );
        }

        private void ModeFollow()
        {
            Character.Body.SetDesiredVelocity(
                GetNormalizedDirectionTo(TargetTransform.position) * _walkSpeed
            );
        }

        private Vector2 GetNormalizedDirectionTo(Vector2 position)
        {
            return (position - Character.Position).normalized;
        }
    }
}
