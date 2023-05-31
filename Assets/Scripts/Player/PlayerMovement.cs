using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public Transform attackCheck;

    private float horizontal;
    private float speed = 6f;
    private float jumpingPower = 14f;
    private bool isFacingRight = true;
    private bool isClimbing;
    private int posicionDisparo;

    private Animator animator;
    private bool isJumping;
    private bool canDoubleJump;
    private int extraJumps = 1;

    [SerializeField] Transform shootingPoint;
    [SerializeField] GameObject bullet;

    GameObject bullets;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        canDoubleJump = false;
        extraJumps = 1;
        posicionDisparo=9;
    }

    private void Update()
    {
        animator.SetFloat("Horizontal", Mathf.Abs(horizontal));

        if (!isFacingRight && horizontal > 0f)
        {
            posicionDisparo=9;
            Flip();
        }
        else if (isFacingRight && horizontal < 0f)
        {
            posicionDisparo=-9;
            Flip();
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        animator.SetBool("enSuelo", IsGrounded());

        if (isClimbing)
        {   
            animator.SetBool("isClimbing", isClimbing);
            if (horizontal != 0f)
            {
                rb.velocity = new Vector2(rb.velocity.x, horizontal * speed);
            }
        }
        else
        {
            animator.SetBool("isClimbing", false);
        }
    }

    public void Move(InputAction.CallbackContext context)
    {
        horizontal = context.ReadValue<Vector2>().x;
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (IsGrounded())
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
                canDoubleJump = true;
                extraJumps = 1;
            }
            else if (extraJumps > 0 && canDoubleJump)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
                extraJumps--;
            }
        }

        if (context.canceled && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }
    }

    public void Climb(InputAction.CallbackContext context)
    {
        if (context.performed && isClimbing)
        {
            horizontal = context.ReadValue<Vector2>().y;
        }
        else if (context.canceled && isClimbing)
        {
            horizontal = 0f;
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("stairs"))
        {
            isClimbing = true;
            rb.gravityScale = 0f; 
            rb.velocity = Vector2.zero;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("stairs"))
        {
            isClimbing = false;
            horizontal = 0f;
            rb.gravityScale = 4f; 
        }
    }

    public void Attack(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            animator.SetTrigger("golpe");
        }
    }

    public void ThrowAttack(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            animator.SetTrigger("lanzar");
            Invoke("InstantiateBullet", 0.3f);

        }

    }

    private void InstantiateBullet(){
        bullets = Instantiate(bullet, shootingPoint);
        bullets.GetComponent<Rigidbody2D>().velocity = new Vector2(posicionDisparo,0);
        bullets.transform.parent = null;
        Destroy(bullets, 3f);
    }
}
