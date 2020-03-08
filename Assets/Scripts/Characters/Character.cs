namespace Sleepy.Characters
{
    using System;
    using UnityEngine;

    [Serializable]
    [RequireComponent(typeof(CharacterBody))]
    [RequireComponent(typeof(CharacterInventory))]
    [RequireComponent(typeof(CharacterController))]
    [RequireComponent(typeof(CharacterCombat))]
    [RequireComponent(typeof(CharacterSensors))]
    public class Character : MonoBehaviour
    {
        [SerializeField]
        private CharacterBody _body;
        public CharacterBody Body { get { return _body; }}
        [SerializeField]
        private CharacterInventory _inventory;
        public CharacterInventory Inventory { get { return _inventory; }}
        [SerializeField]
        private CharacterController _controller;
        public CharacterController Controller { get { return _controller; }}
        [SerializeField]
        private CharacterCombat _combat;
        public CharacterCombat Combat { get { return _combat; }}
        [SerializeField]
        private CharacterSensors _sensors;
        public CharacterSensors Sensors { get { return _sensors; }}
        [SerializeField]
        private Animator _animator;
        public Animator Animator { get { return _animator; }}

        public Vector2 Position { get { return Body.Position; }}
        public Transform Transform { get { return Body.Transform; }}

        private bool _isController = false;
        public bool IsController { get { return _isController; }}

        private BoltEntity _entity;
        public BoltEntity Entity { get { return _entity; }}

        void Awake()
        {
            Body.AssignCharacter(this);
            Controller.AssignCharacter(this);
            Inventory.AssignCharacter(this);
            Inventory.RightHandItemSlot.AssignCharacter(this);
            Combat.AssignCharacter(this);
            Sensors.AssignCharacter(this);
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
