using UnityEngine;
using System.Collections;

public class AttackControllerHuge : MonoBehaviour
{
    public int initialDmg;
    public float attack4Cooldown;

    private int dmg;

    private float lastAttack;
    private bool canPlayAttack4 = true;
    private Animator animator;

    EnemyBasic enemyBasic;

    void Awake()
    {
        animator = GetComponentInParent<Animator>();

        enemyBasic = GetComponentInParent<EnemyBasic>();
    }

    void Start()
    {
        lastAttack = 0f;
        dmg = initialDmg; // Inicializar el daño con el valor inicial
    }

    void Update()
    {
        lastAttack += Time.deltaTime;
    }

    // Atacar cuando la colisión siga permaneciendo
    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Heroe"))
        {
            if (lastAttack >= 2)
            {
                // Han pasado dos segundos desde el último ataque
                lastAttack = 0; // Actualiza el tiempo del último ataque
                Attack(collision);
            }
        }
    }

    public void Attack(Collider2D target)
    {

        string[] attackAnimations = { "Attack1", "Attack2", "Attack4" };
        int randomIndex = Random.Range(0, attackAnimations.Length);
        string randomAnimation = attackAnimations[randomIndex];

        if (randomAnimation == "Attack4" && !canPlayAttack4)
        {
            return; // Si la animación seleccionada es "Attack4" pero no se puede reproducir, salimos de la función
        }

        animator.Play(randomAnimation);

        if (randomAnimation.Equals("Attack4"))
        {
            enemyBasic.velocidadMovimiento = enemyBasic.velocidadMovimiento + 0.5f;
            canPlayAttack4 = false;
            StartCoroutine(ResetAttack4Timer());

        }
        else if (randomAnimation.Equals("Attack1"))
        {
            GameManager.Instance.PerderVida();
            return;
        }
        else if (randomAnimation.Equals("Attack2"))
        {
            GameManager.Instance.PerderVida();
            return;
        }

    }

    private IEnumerator ResetAttack4Timer()
    {
        yield return new WaitForSeconds(attack4Cooldown);
        canPlayAttack4 = true;
    }
}
