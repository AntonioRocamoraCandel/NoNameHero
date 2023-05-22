using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public Transform groundCheck;
    public Transform wallCheck;
    public LayerMask groundLayer;

    private float horizontal;
    private float speed = 8f;
    private float jumpingPower = 16f;
    private bool isFacingRight = true;
    private bool isWallSliding = false; // Nuevo

    [Header("Animacion")]
    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        animator.SetFloat("Horizontal", Mathf.Abs(horizontal));
        if (!isFacingRight && horizontal > 0f)
        {
            Flip();
        }
        else if (isFacingRight && horizontal < 0f)
        {
            Flip();
        }
    }

    private void FixedUpdate()
    {
        bool isGrounded = IsGrounded();
        bool isWallColliding = IsWallColliding();

        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        animator.SetBool("enSuelo", isGrounded);

        // Evitar engancharse en las paredes
        if (isWallColliding && !isGrounded && rb.velocity.y < 0f) // Modificado
        {
            isWallSliding = true; // Nuevo
            rb.velocity = new Vector2(rb.velocity.x, -speed); // Modificado
        }
        else
        {
            isWallSliding = false; // Nuevo
        }
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }
        else if (context.performed && isWallSliding) // Nuevo
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            isWallSliding = false;
        }

        if (context.canceled && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private bool IsWallColliding()
    {
        return Physics2D.OverlapCircle(wallCheck.position, 0.2f, groundLayer);
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }

    public void Move(InputAction.CallbackContext context)
    {
        horizontal = context.ReadValue<Vector2>().x;
    }
}
