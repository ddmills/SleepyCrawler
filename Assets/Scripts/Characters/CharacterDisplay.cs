namespace Sleepy.Characters
{
    using System;
    using UnityEngine;

    [Serializable]
    public class CharacterDisplay : CharacterComponent
    {
        [SerializeField]
        public SpriteRenderer sprite;

        public void Update()
        {
            Character.Animator.SetFloat("Speed", Character.Body.Speed);

            sprite.flipX = Character.Body.MovementDirection.x < 0;
        }
    }
}
