namespace Sleepy.Characters
{
    using Bolt;
    using UnityEngine;

    public class PlayerCharacterBehavior : CharacterBehavior
    {
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
    }
}
