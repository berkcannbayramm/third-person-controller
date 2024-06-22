using UnityEngine;

public class IdleState : ICharacterState
{
    public void EnterState(ThirdPersonMovement character)
    {
    }

    public void UpdateState(ThirdPersonMovement character)
    {
        if (!character.InputManager.IsStopped())
        {
            character.TransitionToState(character.WalkState);
        }

        if (character.InputManager.JumpInput)
        {
            character.TransitionToState(character.JumpState);
        }
    }

    public void ExitState(ThirdPersonMovement character)
    {
    }
}