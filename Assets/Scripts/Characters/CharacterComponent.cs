namespace Sleepy.Characters
{
    using UnityEngine;

    public class CharacterComponent : MonoBehaviour
    {
        private Character _character;
        public Character Character { get { return _character; }}

        public void AssignCharacter(Character character)
        {
            _character = character;
        }
    }
}
