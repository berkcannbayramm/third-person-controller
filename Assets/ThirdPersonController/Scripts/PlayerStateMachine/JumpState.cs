using UnityEngine;

public class JumpState : ICharacterState
{
    public void EnterState(ThirdPersonMovement character)
    {
        character.HandleJump();
    }

    public void UpdateState(ThirdPersonMovement character)
    {
        character.HandleMovement();

        if (character.isGrounded)
        {
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");

            if (horizontal != 0 || vertical != 0)
            {
                character.TransitionToState(character.walkState);
            }
            else
            {
                character.TransitionToState(character.idleState);
            }
        }
    }

    public void ExitState(ThirdPersonMovement character) { }
}
