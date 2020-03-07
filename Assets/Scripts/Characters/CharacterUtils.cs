namespace Sleepy.Characters
{
    using UnityEngine;
    using System.Collections.Generic;

    public static class CharacterUtils
    {
        public static Character[] GetAllCharacters()
        {
            return Object.FindObjectsOfType<Character>();
        }

        public static List<Character> GetCharactersInRadius(Vector2 point, float radius)
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(point, radius);
            List<Character> characters = new List<Character>();

            foreach (Collider2D collider in colliders)
            {
                Character character = collider.GetComponent<Character>();

                if (character != null) {
                    characters.Add(character);
                }
            }

            return characters;
        }
    }
}
