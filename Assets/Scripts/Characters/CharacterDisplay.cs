namespace Sleepy.Characters
{
    using System;
    using UnityEngine;

    [Serializable]
    public class CharacterDisplay : CharacterComponent
    {
        [SerializeField]
        public SpriteRenderer sprite;
        [SerializeField]
        public GameObject bloodEffectPrefab;

        public void Update()
        {
            Character.Animator.SetFloat("Speed", Character.Body.Speed);

            sprite.flipX = Character.Body.MovementDirection.x < 0;
        }

        public void SpawnBlood()
        {
            Instantiate(bloodEffectPrefab, Character.Position, Quaternion.identity);
        }
    }
}
