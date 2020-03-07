namespace Sleepy.Characters
{
    using Bolt;
    using UnityEngine;

    public class PlayerCharacterController : EntityEventListener<ICharacterState>
    {
        [SerializeField]
        private Character _character;
        public Character Character { get { return _character; }}

        public override void Attached()
        {
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
            Vector2 inputAxis = new Vector2(
                Input.GetAxisRaw("Horizontal"),
                Input.GetAxisRaw("Vertical")
            );
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (Input.GetButtonDown("Jump"))
            {
                Character.Body.Dash();
            }

            if (Input.GetMouseButtonDown(0))
            {
                bool attacked = Character.Combat.BasicAttack();
            }

            Character.Body.SetDesiredVelocity(inputAxis.normalized * 2);
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

        public override void OnEvent(StrikeEvent evnt)
        {
            BoltConsole.Write("Character received strike " + evnt.Amount + " of " + evnt.Type + " by " + evnt.Source.name);
            Character.Body.Knockback(evnt.Source.transform.position, 5);
        }
    }
}
