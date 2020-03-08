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
        [SerializeField]
        public Transform frontEffect;

        public void Update()
        {
            Character.Animator.SetFloat("Speed", Character.Body.Speed);

            sprite.flipX = Character.Body.MovementDirection.x < 0;
            frontEffect.localEulerAngles = new Vector3(0, 0, Character.Body.Angle - 90);
        }

        public void SpawnBlood()
        {
            Instantiate(bloodEffectPrefab, Character.Position, Quaternion.identity);
        }
    }
}
