using UnityEngine;
public class AttackController : MonoBehaviour

{
    public int dmg;

    private float lastAttack;
    private Animator animator;
  
    void Awake()
    {
        animator = GetComponentInParent<Animator>();
    }
    void Start()
    {
        lastAttack = 0f;
    }

    
    void Update()
    {
        lastAttack = lastAttack + Time.deltaTime;
    }

    // Atacar cuando la colisión siga permaneciendo
    void OnTriggerStay2D(Collider2D collision){
         if (collision.gameObject.CompareTag("Heroe"))
        {
            if (lastAttack >= 2)
            {
                // Han pasado dos segundos desde el último ataque
                // Tu código para atacar aquí
                lastAttack = 0; // Actualiza el tiempo del último ataque
                attack(collision);
            }
        }
    }

    
    public void attack(Collider2D target){
        bool isAnimationPlaying = animator.GetCurrentAnimatorStateInfo(0).IsName("Hurt");

        if (!isAnimationPlaying){
            animator.Play("Attack");
            GameManager.Instance.PerderVidas(dmg);
        }
        
        
    }
}
