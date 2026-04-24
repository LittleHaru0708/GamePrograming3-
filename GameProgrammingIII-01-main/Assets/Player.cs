using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float jumpSpeed;
    [SerializeField] Transform groundCheck;
    [SerializeField] float groundCheckDistance = 0.1f;
    [SerializeField] LayerMask groundLayer;

    PlayerInput playerInput;
    Rigidbody2D rb;

    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        var move = playerInput.actions["Move"].ReadValue<Vector2>();

        rb.linearVelocityX = move.x * speed;

        bool isGrounded = Physics2D.Raycast(groundCheck.position, Vector2.down, groundCheckDistance, groundLayer);

        if (playerInput.actions["Jump"].WasPressedThisFrame() && isGrounded)
        {
            rb.linearVelocityY = jumpSpeed;
        }
    }
}