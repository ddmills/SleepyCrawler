namespace Sleepy.Characters
{
    using System;
    using UnityEngine;

    [Serializable]
    public class Character : MonoBehaviour
    {
        [SerializeField]
        private CharacterBody _body;
        public CharacterBody Body { get { return _body; }}
        [SerializeField]
        private CharacterInventory _inventory;
        public CharacterInventory Inventory { get { return _inventory; }}
        [SerializeField]
        private CharacterCombat _combat;
        public CharacterCombat Combat { get { return _combat; }}

        private bool _isController = false;
        public bool IsController { get { return _isController; }}

        private BoltEntity _entity;
        public BoltEntity Entity { get { return _entity; }}

        void Awake()
        {
            Body.AssignCharacter(this);
            Inventory.AssignCharacter(this);
            Combat.AssignCharacter(this);
        }

        public void TakeControl()
        {
            _isController = true;
        }

        public void SetEntity(BoltEntity entity)
        {
            _entity = entity;
        }
    }
}
