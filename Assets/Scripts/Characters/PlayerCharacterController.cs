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

            state.AddCallback("Direction", OnDirectionChange);
            state.AddCallback("Velocity", OnVelocityChange);
        }

        public override void SimulateOwner()
        {
            Vector2 inputAxis = new Vector2(
                Input.GetAxisRaw("Horizontal"),
                Input.GetAxisRaw("Vertical")
            );
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (Input.GetButtonDown("Jump"))
            {
                Character.Body.Dash();
            }

            Character.Body.SetVelocity(inputAxis.normalized * 2);
            Character.Body.LookAt(mousePosition);

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
    }
}
