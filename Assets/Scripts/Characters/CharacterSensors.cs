namespace Sleepy.Characters
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using UnityEngine;

    [Serializable]
    public class CharacterSensors : CharacterComponent
    {
        [SerializeField]
        [Range(0, 40)]
        public float maxHostileSearchDistance = 20;

        public bool CanSee(Vector2 position)
        {
            float distance = Character.Body.GetDistanceTo(position);

            return distance <= 10;
        }

        public bool CanSee(GameObject other)
        {
            return CanSee(other.transform.position);
        }

        public bool CanSee(Character other)
        {
            return CanSee(other.Body.Position);
        }

        public bool IsHostileTowards(Character other)
        {
            return other != Character;
        }

        public List<Character> GetDetectedHostiles()
        {
            List<Character> nearby = CharacterUtils.GetCharactersInRadius(Character.Position, maxHostileSearchDistance);

            return nearby
                .Where(IsHostileTowards)
                .Where(CanSee)
                .ToList();
        }
    }
}
