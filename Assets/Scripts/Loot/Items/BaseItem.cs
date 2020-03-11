namespace Sleepy.Loot
{
    using Characters;
    using System;
    using UnityEngine;

    [Serializable]
    [CreateAssetMenu(menuName="Items/Base")]
    public class BaseItem : ScriptableObject
    {
        [Header("Base attributes")]
        public string Name;
        public string Description;
        public Sprite Sprite;
        public string Id;

        public virtual void Use(Character character)
        {
        }
    }
}
