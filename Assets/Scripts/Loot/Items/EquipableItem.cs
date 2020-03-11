namespace Sleepy.Loot
{
    using System;
    using UnityEngine;
    using Combat;

    [Serializable]
    [CreateAssetMenu(menuName="Items/Equipable")]
    public class EquipableItem : BaseItem
    {
        [Tooltip("Prefab to attach to the character. Leave empty for non-rendering items.")]
        public GameObject EquippedPrefab;

        [Tooltip("Allowed equiptment slots")]
        public EquipmentSlot[] AllowedSlots;
    }
}
