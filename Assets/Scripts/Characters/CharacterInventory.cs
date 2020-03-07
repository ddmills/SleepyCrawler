namespace Sleepy.Characters
{
    using Loot;
    using UnityEngine;

    public class CharacterInventory : MonoBehaviour
    {
        private Character _character;
        public Character Character { get { return _character; }}

        [SerializeField]
        private HandItemSlot rightHandItemSlot;
        [SerializeField]
        private ItemData rightHandItemData;
        public ItemData Weapon { get { return rightHandItemData; }}

        public void Awake()
        {
            rightHandItemSlot.SetItemData(rightHandItemData);
        }

        public void AssignCharacter(Character character)
        {
            _character = character;
            rightHandItemSlot.AssignCharacter(character);
        }
    }
}
