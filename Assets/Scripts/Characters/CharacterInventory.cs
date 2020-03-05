namespace Sleepy.Characters
{
    using System;
    using UnityEngine;

    [Serializable]
    public class CharacterInventory : MonoBehaviour
    {
        private Character _character;
        public Character Character { get { return _character; }}

        [SerializeField]
        private Transform rightHand;
        [SerializeField]
        private GameObject itemPrefab;
        private GameObject item;

        public void Start()
        {
            item = Instantiate(itemPrefab, rightHand);
            item.transform.localPosition = Vector2.zero;
        }

        public void AssignCharacter(Character character)
        {
            _character = character;
        }

        void Update()
        {
            Vector2 direction = Character.Body.Direction;
            rightHand.localPosition = direction;

            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            item.transform.localEulerAngles = new Vector3(0, 0, angle - 45);
        }
    }
}
