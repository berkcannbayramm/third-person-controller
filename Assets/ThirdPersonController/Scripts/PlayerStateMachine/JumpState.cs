using UnityEngine;

public class JumpState : ICharacterState
{
    public void EnterState(ThirdPersonMovement character)
    {
        character.HandleJump();
        character.InputManager.JumpInput = false;
    }

    public void UpdateState(ThirdPersonMovement character)
    {
        character.HandleMovement();

        if (character.IsGrounded)
        {
            if (!character.InputManager.IsStopped())
            {
                character.TransitionToState(character.WalkState);
            }
            else
            {
                character.TransitionToState(character.IdleState);
            }
        }
    }

    public void ExitState(ThirdPersonMovement character) { }
}
