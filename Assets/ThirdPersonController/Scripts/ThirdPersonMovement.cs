using UnityEngine;
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
    public bool isGrounded { get; private set; }
    public readonly WalkState walkState = new WalkState();
    public readonly JumpState jumpState = new JumpState();
    public readonly IdleState idleState = new IdleState();

    float turnSmoothVelocity;
    Vector3 velocity;

    ICharacterState currentState;
    void Start()
    {
        TransitionToState(idleState);
    }

    void Update()
    {
        HandleGroundCheck();
        currentState.UpdateState(this);
        controller.Move(velocity * Time.deltaTime);
    }

    public void TransitionToState(ICharacterState newState)
    {
        currentState?.ExitState(this);
        currentState = newState;
        currentState.EnterState(this);
    }

    public void HandleGroundCheck()
    {
        isGrounded = controller.isGrounded;
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        if (!isGrounded)
        {
            velocity.y += gravity * Time.deltaTime;
        }
    }

    public void HandleMovement()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
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
        velocity.y = jumpSpeed;
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
        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
        transform.rotation = Quaternion.Euler(0f, angle, 0f);
    }
}
