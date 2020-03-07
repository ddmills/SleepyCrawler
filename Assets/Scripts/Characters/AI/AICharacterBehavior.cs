namespace Sleepy.Characters.AI
{
    using UnityEngine;
    using Bolt;
    using Characters;

    public class AICharacterBehavior : Characters.CharacterBehavior
    {
        [SerializeField]
        private Brain _brain;
        public Brain Brain { get { return _brain; }}

        [SerializeField]
        [Range(0, 3)]
        [Tooltip("How often the brain should reevaluate behavior")]
        private float thinkDelaySeconds = .5f;
        private float lastThought;

        public override void Attached()
        {
            lastThought = BoltNetwork.Time;
            state.SetTransforms(state.Transform, transform);
            Character.SetEntity(entity);

            if (entity.IsOwner)
            {
                Character.TakeControl();
            }

            state.AddCallback("Direction", OnDirectionChange);
            state.AddCallback("Velocity", OnVelocityChange);
        }

        public override void SimulateOwner()
        {
            Think();
            state.Direction = Character.Body.Direction;
            state.Velocity = Character.Body.Velocity;
        }

        private void Think()
        {
            if (lastThought + thinkDelaySeconds < BoltNetwork.Time)
            {
                IBehavior behavior = Brain.Think(Character);
                behavior.Behave(Character);
                lastThought = BoltNetwork.Time;
            }
        }
    }
}
