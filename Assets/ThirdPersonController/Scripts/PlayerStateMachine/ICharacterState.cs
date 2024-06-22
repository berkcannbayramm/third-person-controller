public interface ICharacterState
{
    void EnterState(ThirdPersonMovement character);
    void UpdateState(ThirdPersonMovement character);
    void ExitState(ThirdPersonMovement character);
}
