namespace Sleepy.Loot
{
    using System;
    using UnityEngine;

    [Serializable]
    [CreateAssetMenu(menuName="Items/Misc/EquipmentSlot")]
    public class EquipmentSlot : ScriptableObject
    {
        public string Name;
    }
}
