namespace Sleepy.Characters.AI
{
    using System;
    using System.Collections.Generic;
    using UnityEngine;
    using Characters;

    [Serializable]
    public class Brain : MonoBehaviour
    {
        private IBehavior _behaviour;
        public IBehavior Behaviour { get { return _behaviour; }}

        public virtual IBehavior Think(Character character)
        {
            _behaviour = new IdleBehavior();

            List<Character> hostiles = character.Sensors.GetDetectedHostiles();

            if (hostiles.Count > 1)
            {
                _behaviour = new FleeBehavior(hostiles[0]);
                return _behaviour;
            }
            else if (hostiles.Count == 1)
            {
                _behaviour = new MeleeAttackBehavior(hostiles[0]);
                return _behaviour;
            }

            return _behaviour;
        }
    }
}
