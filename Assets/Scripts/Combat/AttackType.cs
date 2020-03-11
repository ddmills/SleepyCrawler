namespace Sleepy.Combat
{
    using System;
    using UnityEngine;
    using Characters;

    [Serializable]
    [CreateAssetMenu(menuName="Combat/AttackType")]
    public class AttackType : ScriptableObject
    {
        [Header("Description")]
        public string Name;
        public string Description;
        [Header("Collider")]
        public Vector2 ColliderSize;
        public float ColliderOffset;
        [Header("Effects")]
        public GameObject EffectPrefab;

        public Collider2D[] GetColliders(Character character)
        {
            return character.Body.CastBoxInFront(ColliderSize, ColliderOffset);
        }

        public float Range(Character character)
        {
            return ColliderSize.y + ColliderOffset;
        }
    }
}
