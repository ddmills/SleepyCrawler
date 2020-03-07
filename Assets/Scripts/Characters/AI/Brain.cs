namespace Sleepy.Characters.AI
{
    using System;
    using System.Collections.Generic;
    using UnityEngine;
    using Characters;

    [Serializable]
    public class Brain : MonoBehaviour
    {
        private IBehavior currentBehavior;

        public virtual IBehavior Think(Character character)
        {
            currentBehavior = new IdleBehavior();

            // List<Character> hostiles = character.Sensors.GetDetectedHostiles();

            // if (hostiles.Count > 1)
            // {
            //     currentBehavior = new FleeBehavior(hostiles[0]);
            //     return currentBehavior;
            // }
            // else if (hostiles.Count == 1)
            // {
            //     currentBehavior = new FollowBehavior(hostiles[0]);
            //     return currentBehavior;
            // }

            return currentBehavior;
        }
    }
}
