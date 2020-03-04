namespace Sleepy.Characters
{
    using System;
    using UnityEngine;

    [Serializable]
    public class CharacterBody : MonoBehaviour
    {
        private Character _character;
        public Character Character { get { return _character; }}
        private Vector2 _velocity;
        public Vector2 Velocity { get { return _velocity; }}
        public Vector2 Position { get { return transform.position; }}

        public void AssignCharacter(Character character)
        {
            _character = character;
        }

        public void SetVelocity(Vector2 velocity)
        {
            _velocity = velocity;
        }

        public void FixedUpdate()
        {
            if (Character.IsController)
            {
                transform.position = Position + Velocity * Time.fixedDeltaTime;
            }
        }
    }
}
