namespace Sleepy.Characters
{
    using Loot;
    using UnityEngine;

    public class CharacterInventory : CharacterComponent
    {
        [SerializeField]
        private HandItemSlot _rightHandItemSlot;
        public HandItemSlot RightHandItemSlot { get { return _rightHandItemSlot; }}
        [SerializeField]
        private ItemData rightHandItemData;
        public ItemData Weapon { get { return rightHandItemData; }}

        public void Awake()
        {
            RightHandItemSlot.SetItemData(rightHandItemData);
        }
    }
}
