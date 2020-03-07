namespace Sleepy.Loot
{
    using Characters;
    using UnityEngine;

    public class HandItemSlot : CharacterComponent
    {
        [SerializeField]
        private SpriteRenderer spriteRenderer;
        [SerializeField]
        private ItemData _itemData;
        public ItemData ItemData { get { return _itemData; }}

        public void SetItemData(ItemData data)
        {
            _itemData = data;
            spriteRenderer.sprite = data.LoadSprite();
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

            transform.localEulerAngles = new Vector3(0, 0, Character.Body.Angle);
        }
    }
}
