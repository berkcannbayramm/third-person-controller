using UnityEngine;

public class IdleState : ICharacterState
{
    public void EnterState(ThirdPersonMovement character)
    {
    }

    public void UpdateState(ThirdPersonMovement character)
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        if (horizontal != 0 || vertical != 0)
        {
            character.TransitionToState(character.walkState);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            character.TransitionToState(character.jumpState);
        }
    }

    public void ExitState(ThirdPersonMovement character)
    {
    }
}