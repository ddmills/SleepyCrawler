namespace Sleepy.Characters
{
    using Bolt;
    using UnityEngine;

    public class CharacterBehavior : EntityEventListener<ICharacterState>
    {
        [SerializeField]
        private Character _character;
        public Character Character { get { return _character; }}

        public override void Attached()
        {
            state.SetTransforms(state.Transform, transform);
            state.SetAnimator(Character.Animator);
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
            state.Direction = Character.Body.Direction;
            state.Velocity = Character.Body.Velocity;
        }

        public void OnDirectionChange()
        {
            Character.Body.SetDirection(state.Direction);
        }

        public void OnVelocityChange()
        {
            Character.Body.SetVelocity(state.Velocity);
        }

        public override void OnEvent(StrikeEvent evnt)
        {
            BoltConsole.Write("Character received strike " + evnt.Amount + " of " + evnt.Type + " by " + evnt.Source.name);
            Character.Body.Knockback(evnt.Source.transform.position, 10);
            Character.Display.SpawnBlood();
        }
    }
}
