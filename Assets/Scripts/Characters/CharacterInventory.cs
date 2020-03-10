namespace Sleepy.Characters
{
    using Loot;
    using UnityEngine;

    public class CharacterInventory : CharacterComponent
    {
        [SerializeField]
        private HandItemSlot _primarySlot;
        public HandItemSlot PrimarySlot { get { return _primarySlot; }}
        [SerializeField]
        private ItemData rightHandItemData;
        public ItemData Weapon { get { return rightHandItemData; }}
        public MeleeWeaponItem MeleeWeapon;

        public void Awake()
        {
            // RightHandItemSlot.SetItemData(rightHandItemData);
            PrimarySlot.Assign(MeleeWeapon);
        }

        public void UsePrimary()
        {
            PrimarySlot.Use();
        }
    }
}
