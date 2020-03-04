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

        private bool _isController = false;
        public bool IsController { get { return _isController; }}

        void Awake()
        {
            Body.AssignCharacter(this);
        }

        public void TakeControl()
        {
            _isController = true;
        }
    }
}
