using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movimento")]
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpHeight = 2f;
    [SerializeField] private float gravity = -9.81f;

    [Header("Camera")]
    [SerializeField] private Transform headTarget;
    [SerializeField] private float mouseSensitivity = 2f;

    [Header("Animator")]
    [SerializeField] private Animator animations;

    private CharacterController controller;
    private Vector3 velocity;

    private float pitch;
    private float rotationY;

    private bool wasMoving;

    void Start()
    {
        controller = GetComponent<CharacterController>();

        if (animations == null)
        {
            Debug.LogError("Animator não foi atribuído no Inspector!");
        }

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        HandleMovement();
        HandleRotation();
        UpdateAnimations();
    }

    private void UpdateAnimations()
    {
        if (animations == null)
            return;

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        float movementAmount = new Vector2(horizontal, vertical).magnitude;

        animations.SetFloat("MoveX", horizontal);
        animations.SetFloat("MoveY", vertical);

        bool isJumping = !controller.isGrounded;
        animations.SetBool("IsJumping", isJumping);

        if (movementAmount < 0.1f && wasMoving)
        {
            animations.SetTrigger("StopMoving");
        }

        wasMoving = movementAmount > 0.1f;
    }

    private void HandleMovement()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 moveDirection =
            transform.right * horizontal +
            transform.forward * vertical;

        bool grounded = controller.isGrounded;

        if (grounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        Vector3 finalMove =
            moveDirection.normalized * speed +
            Vector3.up * velocity.y;

        controller.Move(finalMove * Time.deltaTime);
    }

    private void HandleRotation()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxisRaw("Mouse Y") * mouseSensitivity;

        rotationY += mouseX;

        pitch -= mouseY;
        pitch = Mathf.Clamp(pitch, -80f, 80f);

        transform.rotation = Quaternion.Euler(0f, rotationY, 0f);

        if (headTarget != null)
        {
            headTarget.localRotation =
                Quaternion.Euler(pitch, 0f, 0f);
        }
    }
}
