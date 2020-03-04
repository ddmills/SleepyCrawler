namespace Sleepy.Characters
{
    using Bolt;
    using UnityEngine;

    public class PlayerCharacterController : EntityBehaviour<ICharacterState>
    {
        [SerializeField]
        private Character _character;
        public Character Character { get { return _character; }}

        public override void Attached()
        {
            state.SetTransforms(state.Transform, transform);

            if (entity.IsOwner)
            {
                Character.TakeControl();
            }
        }

        public override void SimulateOwner()
        {
            Vector2 inputAxis = new Vector2(
                Input.GetAxisRaw("Horizontal"),
                Input.GetAxisRaw("Vertical")
            );

            Character.Body.SetVelocity(inputAxis.normalized * 2);
        }
    }
}
