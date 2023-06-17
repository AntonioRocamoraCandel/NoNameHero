using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;

public class PlayerMovement : MonoBehaviour
{
    public TransicionEscena transicionEscena;
    public GameManager gameManager;
    public Rigidbody2D rb;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public Transform attackCheck;
    public Transform wallCheck;
    public LayerMask wall;

    private float vertical;
    private bool isLadder;
    private float horizontal;
    private float speed = 6f;
    private float jumpingPower = 13f;
    private bool isFacingRight = true;
    private bool isClimbing;
    private int posicionDisparo;
    private int posicionDisparoMagia;

    public Animator animator;
    public AudioSource audioSource;
    public AudioClip jumpSound;
    public AudioClip fireballSound;
    public AudioClip hurtSound;
    public AudioClip rockSound;
    public AudioClip punchSound;
    public AudioClip deathSound;
    public GameObject menuPausa;
    public GameObject gameOver;
    public GameObject confirmacionReinicio;
    public GameObject confirmacionSalir;
    public GameObject confirmacionControles;
    public GameObject controlesTeclado;
    public GameObject controlesMando;
    private bool isJumping;
    private bool canDoubleJump;
    private int extraJumps = 1;

    private bool isWallSliding;
    private float wallSlidingSpeed = 2f;

    private bool isWallJumping;
    private float wallJumpingDirection;
    private float wallJumpingTime = 0.2f;
    private float wallJumpingCounter;
    private float wallJumpingDuration = 0.4f;
    private Vector2 wallJumpingPower = new Vector2(8f, 16f);

    [SerializeField] Transform shootingPoint;
    [SerializeField] GameObject bullet;
    [SerializeField] Transform shootingPointMagic;
    [SerializeField] GameObject magicBullet;

    GameObject bullets;
    GameObject bulletsMagic;

    public Slider visualMana;
    public float mana;
    public int costoMana;

    private bool canAttack = true;
    private float attackCooldown = 0.6f;
    private float lastAttackTime;

    private bool canThrowAttack = true;
    private float ThrowAttackCooldown = 1.5f;
    private float lastThrowAttackTime;

    private bool canMagicAttack = true;
    private float MagicAttackCooldown = 3f;
    private float lastMagicAttackTime;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        GameManager.Instance.playerMovement = this;
        canDoubleJump = false;
        extraJumps = 1;
        posicionDisparo = 9;
        posicionDisparoMagia = 6;
        audioSource=GetComponent<AudioSource>();
        StartCoroutine(tiempo());
    }

    private void Update()
    {
        if(menuPausa.activeSelf || gameOver.activeSelf || confirmacionControles.activeSelf ||controlesMando.activeSelf ||controlesTeclado.activeSelf ||
        confirmacionSalir.activeSelf ||confirmacionReinicio.activeSelf){
            GetComponent<PlayerInput>().enabled = false;
        }else{
            GetComponent<PlayerInput>().enabled = true;
        }
        animator.SetFloat("Horizontal", Mathf.Abs(horizontal));

        visualMana.GetComponent<Slider>().value = mana;

        if (!isFacingRight && horizontal > 0f)
        {
            posicionDisparoMagia = 6;
            posicionDisparo = 9;
            Flip();
        }
        else if (isFacingRight && horizontal < 0f)
        {
            posicionDisparoMagia = -6;
            posicionDisparo = -9;
            Flip();
        }
        if (InputSystem.GetDevice<Gamepad>() != null)
        {
            if (Gamepad.current.buttonSouth.wasPressedThisFrame)
            {
                Jump();
            }
        }
        if (InputSystem.GetDevice<Keyboard>() != null)
        {
            if (Keyboard.current[Key.Space].wasPressedThisFrame)
            {
                Jump();
            }
        }
        WallSlide();
        WallJump();
        

        if (!canAttack && Time.time >= lastAttackTime + attackCooldown)
        {
            canAttack = true;
        }
        if (!canMagicAttack && Time.time >= lastMagicAttackTime + MagicAttackCooldown && mana >= costoMana)
        {
            canMagicAttack = true;
        }
        if (!canThrowAttack && Time.time >= lastThrowAttackTime + ThrowAttackCooldown)
        {
            canThrowAttack = true;
        }
        if (isLadder && Mathf.Abs(vertical) > 0f)
        {
            isClimbing = true;
        }
        else
        {
            isClimbing = false;
        }

    }

    private void FixedUpdate()
    {
        if (!isWallSliding)
        {
            rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        }
        if(gameManager.sePuedeMover){
            animator.SetBool("enSuelo", IsGrounded());
        }else{
            animator.SetBool("enSuelo", true);
        }
        
        animator.SetBool("isClimbing", false);
        if (isClimbing)
        {
            rb.gravityScale = 0f;
            rb.velocity = new Vector2(rb.velocity.x, vertical * speed);
            animator.SetBool("isClimbing", true);
        }
        else
        {
            rb.gravityScale = 5f;
        }
    }

    public void Move(InputAction.CallbackContext context)
    {
        if(gameManager.sePuedeMover && gameManager.vidas > 0){
            horizontal = context.ReadValue<Vector2>().x;
            GetComponent<PlayerInput>().enabled = true;
        }else if(gameManager.vidas>0 && !gameManager.sePuedeMover){
            horizontal = 0; 
            GetComponent<PlayerInput>().enabled = true;
        }else{
            horizontal = 0;
            GetComponent<PlayerInput>().enabled = false;
        }
    }

    public void Jump()
    {
        if (gameManager.sePuedeMover && gameManager.vidas > 0)
        {
            if (IsGrounded())
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
                canDoubleJump = true;
                extraJumps = 1;
                audioSource.PlayOneShot(jumpSound);
            }
            else if (extraJumps > 0 && canDoubleJump)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
                audioSource.PlayOneShot(jumpSound);
                extraJumps--;
            }
            else if (IsWalled())
            {
                audioSource.PlayOneShot(jumpSound);
                WallJump();
            }
        }
    }

    public void Climb(InputAction.CallbackContext context)
    {
        vertical = context.ReadValue<float>();
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
        isLadder = true;
    }

    if (collision.CompareTag("cambioEscena"))
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;

        string[] sceneOrder = { "City", "SceneLevel2", "Antonio", "kawtar", "FinalBossScene"};

        if (sceneOrder.Any(scene => scene.Equals(sceneName, StringComparison.OrdinalIgnoreCase)))
        {
            //int currentIndex = Array.IndexOf(sceneOrder, sceneName);
            Debug.Log(VariablesGlobales.currentIndex);
            //Debug.Log(sceneOrder[1]);

            if (sceneName.Equals("SceneLevel2", StringComparison.OrdinalIgnoreCase))
            {
                StartCoroutine(CambiarEscena("City"));
                VariablesGlobales.currentIndex++;
            }else if (sceneName.Equals("Antonio", StringComparison.OrdinalIgnoreCase))
            {
                StartCoroutine(CambiarEscena("City"));
                VariablesGlobales.currentIndex++;
            }else if (sceneName.Equals("kawtar", StringComparison.OrdinalIgnoreCase))
            {
                StartCoroutine(CambiarEscena("City"));
                VariablesGlobales.currentIndex++;
            }else if (sceneName.Equals("FinalBossScene", StringComparison.OrdinalIgnoreCase))
            {
                //Termina el juego
            }else if (sceneName.Equals("City", StringComparison.OrdinalIgnoreCase))
            {
                if(VariablesGlobales.currentIndex==0){
                    StartCoroutine(CambiarEscena("SceneLevel2"));
                }else if(VariablesGlobales.currentIndex==1){
                    StartCoroutine(CambiarEscena("Antonio"));
                }else if(VariablesGlobales.currentIndex==2){
                    StartCoroutine(CambiarEscena("kawtar"));
                }else if(VariablesGlobales.currentIndex==3){
                    StartCoroutine(CambiarEscena("FinalBossScene"));
                }
            }
        
        }
    }
}



    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("stairs"))
        {
            isLadder = false;
            isClimbing = false;
        }
    }

    public void Attack(InputAction.CallbackContext context)
    {
        if(gameManager.sePuedeMover && gameManager.vidas > 0){
            if (context.performed && canAttack)
            {
                animator.SetTrigger("golpe");
                audioSource.PlayOneShot(punchSound);
                canAttack = false;
                lastAttackTime = Time.time;
            }
        }
    }

    public void ThrowAttack(InputAction.CallbackContext context)
    {
        if(gameManager.sePuedeMover && gameManager.vidas > 0){
            if (context.started && canThrowAttack)
            {
                animator.SetTrigger("lanzar");
                Invoke("InstantiateBullet", 0.3f);
                audioSource.PlayOneShot(rockSound);
                canThrowAttack = false;
                lastThrowAttackTime = Time.time;

            }
        }


    }

    private void InstantiateBullet()
    {
        bullets = Instantiate(bullet, shootingPoint.position, shootingPoint.rotation);
        bullets.GetComponent<Rigidbody2D>().velocity = new Vector2(posicionDisparo, 0);
    }

    public void MagicAttack(InputAction.CallbackContext context)
    {
        if(gameManager.sePuedeMover && gameManager.vidas > 0){
            if (context.started && canMagicAttack)
            {
                animator.SetTrigger("lanzarMagia");
                Invoke("InstantiateBulletMagic", 0.3f);
                audioSource.PlayOneShot(fireballSound);
                mana -= costoMana;
                canMagicAttack = false;
                lastMagicAttackTime = Time.time;
            }
        }
    }

    private void InstantiateBulletMagic()
    {
        bulletsMagic = Instantiate(magicBullet, shootingPointMagic.position, shootingPointMagic.rotation);
        bulletsMagic.GetComponent<Rigidbody2D>().velocity = new Vector2(posicionDisparoMagia, 0);
        if(posicionDisparoMagia<0){
            Vector3 scale = bulletsMagic.transform.localScale;
            scale.x = -Mathf.Abs(scale.x);
            bulletsMagic.transform.localScale = scale;
        }
    }

    private void StopWallJumping()
    {
        isWallJumping = false;
    }

    private void WallSlide()
    {
        if (IsWalled() && !IsGrounded() && horizontal != 0f)
        {
            rb.gravityScale = 20f;
            isWallSliding = true;
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y, -wallSlidingSpeed, float.MaxValue));
        }
        else
        {
            rb.gravityScale = 5f;
            isWallSliding = false;
        }
    }

    private bool IsWalled()
    {
        return Physics2D.OverlapCircle(wallCheck.position, 0.2f, wall);
    }

    private void WallJump()
    {
        if (isWallSliding)
        {
            isWallJumping = false;
            wallJumpingDirection = -transform.localScale.x;
            wallJumpingCounter = wallJumpingTime;

            CancelInvoke(nameof(StopWallJumping));
        }
        else
        {
            wallJumpingCounter -= Time.deltaTime;
        }

        if (InputSystem.GetDevice<Keyboard>() != null)
        {
            if (Keyboard.current[Key.Space].wasPressedThisFrame && wallJumpingCounter > 0f)
            {
                isWallJumping = true;
                rb.velocity = new Vector2(wallJumpingDirection * wallJumpingPower.x, wallJumpingPower.y);
                wallJumpingCounter = 0f;

                if (transform.localScale.x != wallJumpingDirection)
                {
                    isFacingRight = !isFacingRight;
                    Vector3 localScale = transform.localScale;
                    localScale.x *= -1f;
                    transform.localScale = localScale;
                }

                Invoke(nameof(StopWallJumping), wallJumpingDuration);
            }
        }
        if (InputSystem.GetDevice<Gamepad>() != null)
        {
            if (Gamepad.current.buttonSouth.wasPressedThisFrame && wallJumpingCounter > 0f)
            {
                isWallJumping = true;
                rb.velocity = new Vector2(wallJumpingDirection * wallJumpingPower.x, wallJumpingPower.y);
                wallJumpingCounter = 0f;

                if (transform.localScale.x != wallJumpingDirection)
                {
                    isFacingRight = !isFacingRight;
                    Vector3 localScale = transform.localScale;
                    localScale.x *= -1f;
                    transform.localScale = localScale;
                }

                Invoke(nameof(StopWallJumping), wallJumpingDuration);
            }
        }
    }

    IEnumerator tiempo()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            if (mana < 100)
            {
                mana += 1;
            }
        }
    }

    public void DestruirProtagonista()
    {
        Destroy(gameObject);
    }

    IEnumerator CambiarEscena(String escena){
        transicionEscena.animator.SetTrigger("Iniciar");

        yield return new WaitForSeconds(transicionEscena.animacionFinal.length);
        SceneManager.LoadScene(escena);
    }
}