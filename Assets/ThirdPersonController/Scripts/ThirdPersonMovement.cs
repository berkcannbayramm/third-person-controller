using UnityEngine;
using UnityEngine.InputSystem;
public class ThirdPersonMovement : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] CharacterController controller;
    [SerializeField] Transform cameraTransform;

    [Header("Movement Settings")]
    [SerializeField] float groundSpeed = 6f;
    [SerializeField] float jumpSpeed = 8.0f;
    [SerializeField] float turnSmoothTime = 0.1f;
    [SerializeField] float gravity = -9.81f;
    public bool IsGrounded { get; private set; }
    public InputManager InputManager { get; set; }

    public readonly WalkState WalkState = new WalkState();
    public readonly JumpState JumpState = new JumpState();
    public readonly IdleState IdleState = new IdleState();

    float _turnSmoothVelocity;
    Vector3 _velocity;
    ICharacterState _currentState;

    private void Awake()
    {
        InputManager = GetComponent<InputManager>();
    }

    void Start()
    {
        TransitionToState(IdleState);
    }

    void Update()
    {
        InputManager.HandleAllInputs();

        HandleGroundCheck();
        _currentState.UpdateState(this);
        controller.Move(_velocity * Time.deltaTime);
    }

    public void TransitionToState(ICharacterState newState)
    {
        _currentState?.ExitState(this);
        _currentState = newState;
        _currentState.EnterState(this);
    }

    public void HandleGroundCheck()
    {
        IsGrounded = controller.isGrounded;
        if (IsGrounded && _velocity.y < 0)
        {
            _velocity.y = -2f;
        }
        if (!IsGrounded)
        {
            _velocity.y += gravity * Time.deltaTime;
        }
    }

    public void HandleMovement()
    {
        float horizontal = InputManager.HorizontalInput;
        float vertical = InputManager.VerticalInput;
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float currentSpeed = groundSpeed;
            Vector3 moveDirection = CalculateMoveDirection(horizontal, vertical);

            RotateCharacter(moveDirection);
            controller.Move(moveDirection.normalized * currentSpeed * Time.deltaTime);
        }
    }
    public void HandleJump()
    {
        _velocity.y = jumpSpeed;
    }

    public Vector3 CalculateMoveDirection(float horizontal, float vertical)
    {
        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;

        forward.y = 0f;
        right.y = 0f;
        forward.Normalize();
        right.Normalize();

        return forward * vertical + right * horizontal;
    }

    public void RotateCharacter(Vector3 moveDirection)
    {
        float targetAngle = Mathf.Atan2(moveDirection.x, moveDirection.z) * Mathf.Rad2Deg;
        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref _turnSmoothVelocity, turnSmoothTime);
        transform.rotation = Quaternion.Euler(0f, angle, 0f);
    }
}
