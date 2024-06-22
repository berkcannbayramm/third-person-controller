using UnityEngine;

public class WalkState : ICharacterState
{
    public void EnterState(ThirdPersonMovement character)
    {
    }

    public void UpdateState(ThirdPersonMovement character)
    {
        character.HandleMovement();

        if (character.InputManager.JumpInput)
        {
            character.TransitionToState(character.JumpState);
        }

        if (character.InputManager.IsStopped() && character.IsGrounded)
        {
            character.TransitionToState(character.IdleState);
        }
    }

    public void ExitState(ThirdPersonMovement character) { }
}
