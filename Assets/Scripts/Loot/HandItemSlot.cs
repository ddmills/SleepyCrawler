namespace Sleepy.Loot
{
    using Characters;
    using UnityEngine;

    public class HandItemSlot : MonoBehaviour
    {
        private Character _character;
        public Character Character { get { return _character; }}
        [SerializeField]
        private SpriteRenderer spriteRenderer;
        [SerializeField]
        private ItemData _itemData;
        public ItemData ItemData { get { return _itemData; }}

        public void AssignCharacter(Character character)
        {
            _character = character;
        }

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

            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            transform.localEulerAngles = new Vector3(0, 0, angle);
        }
    }
}
