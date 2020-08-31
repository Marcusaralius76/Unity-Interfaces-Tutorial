using UnityEngine;
public class MoveWithControls : MonoBehaviour
{
    private CharacterController controller;
    public float moveSpeed = 10f;
    public float sprintSpeed = 25f;
    private float netSpeed;
    [SerializeField] private Transform groundCheck = null;
    [SerializeField] private LayerMask groundMask = 0;
    [SerializeField] private LayerMask baseMask = 0;
    public float groundDistance = 0.4f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    private Vector3 velocity;
    private Vector2 moveKeys;
    private bool isGrounded;
    private bool isOnBase;
    void Start()
    {
        netSpeed = moveSpeed;
        controller = GetComponent<CharacterController>();
    }
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        isOnBase = Physics.CheckSphere(groundCheck.position, groundDistance, baseMask);
        if ((isGrounded || isOnBase) && velocity.y < 0f) velocity.y = -2f;
        moveKeys.x = Input.GetAxis("Horizontal");
        moveKeys.y = Input.GetAxis("Vertical");
        Vector3 move = transform.right * moveKeys.x + transform.forward * moveKeys.y;
        if (Input.GetButtonDown("Sprint")) netSpeed = sprintSpeed;
        if (Input.GetButtonUp("Sprint")) netSpeed = moveSpeed;
        controller.Move(move * netSpeed * Time.deltaTime);
        if (Input.GetButtonDown("Jump") && (isGrounded || isOnBase)) velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}