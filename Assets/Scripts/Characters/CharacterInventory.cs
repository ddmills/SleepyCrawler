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
        public MeleeWeaponItem Item;

        public void Awake()
        {
            PrimarySlot.Assign(Item);
        }

        public void UsePrimary()
        {
            if (PrimarySlot.Use())
            {
                ItemUseData data = new ItemUseData(0);
                data.ToBoltItemUseEventEvent(Character.Entity).Send();
            }
        }

        public bool CanUsePrimary()
        {
            return true;
        }

        public void SpawnPrimaryEffects(ItemUseData data)
        {
            Item.SpawnUseEffects(Character);
        }
    }
}
