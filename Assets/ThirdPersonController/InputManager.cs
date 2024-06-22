using UnityEngine;

public class InputManager : MonoBehaviour
{
    PlayerInputs playerControls;

    public Vector2 MovementInput;

    public float VerticalInput;
    public float HorizontalInput;

    public bool JumpInput;

    private void OnEnable()
    {
        if(playerControls == null)
        {
            playerControls = new PlayerInputs();

            playerControls.PlayerMovement.Movement.performed += i => MovementInput = i.ReadValue<Vector2>();

            playerControls.PlayerActions.Jump.performed += i => JumpInput = true;
        }

        playerControls.Enable();
    }
    private void OnDisable()
    {
        playerControls.Disable();
    }

    public void HandleAllInputs()
    {
        HandleMovementInput();
    }

    void HandleMovementInput()
    {
        VerticalInput = MovementInput.y;
        HorizontalInput = MovementInput.x;
    }
    public bool IsStopped() => VerticalInput == 0 && HorizontalInput == 0;
}
