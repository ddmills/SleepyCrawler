namespace Sleepy.Loot
{
    using Characters;
    using UnityEngine;

    public class HandItemSlot : CharacterComponent
    {
        [SerializeField]
        private SpriteRenderer spriteRenderer;
        [SerializeField]
        private EquipableItem _item;
        public EquipableItem Item { get { return _item; }}

        public void Assign(EquipableItem item)
        {
            _item = item;
            spriteRenderer.sprite = item.Sprite;
        }

        public void Use()
        {
            if (Item != null)
            {
                Item.Use(Character);
            }
        }

        public void Update()
        {
            Vector2 direction = Character.Body.Direction;

            if (direction.y > 0)
            {
                spriteRenderer.sortingLayerName = "behind";
            }
            else
            {
                spriteRenderer.sortingLayerName = "front";
            }

            transform.localEulerAngles = new Vector3(0, 0, Character.Body.Angle - 135);
        }
    }
}
