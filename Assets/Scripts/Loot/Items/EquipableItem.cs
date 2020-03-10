namespace Sleepy.Loot
{
    using System;
    using UnityEngine;
    using Combat;

    [Serializable]
    [CreateAssetMenu(menuName="Items/Equipable")]
    public class EquipableItem : BaseItem
    {
        [Tooltip("Allowed equiptment slots")]
        public EquipmentSlot[] AllowedSlots;
    }
}
