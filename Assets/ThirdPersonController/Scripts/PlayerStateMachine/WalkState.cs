using UnityEngine;

public class WalkState : ICharacterState
{
    public void EnterState(ThirdPersonMovement character)
    {
    }

    public void UpdateState(ThirdPersonMovement character)
    {
        character.HandleMovement();

        if (Input.GetKey(KeyCode.Space))
        {
            character.TransitionToState(character.jumpState);
        }

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        if (horizontal == 0 && vertical == 0 && character.isGrounded)
        {
            character.TransitionToState(character.idleState);
        }
    }

    public void ExitState(ThirdPersonMovement character) { }
}
