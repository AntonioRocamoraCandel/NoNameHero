using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class AttackController : MonoBehaviour

{
    public int dmg;
    private bool animationAttack = false;
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

    // Atacar cuando sea la primera vez que se colisiona
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Heroe"))
        {
            if (lastAttack >= 2)
            {
                // Han pasado dos segundos desde el último ataque
                // Tu código para atacar aquí
                lastAttack = 0; // Actualiza el tiempo del último ataque
                attack(dmg);
            }
        }
    }

    // Atacar cuando la colisión siga permaneciendo
    void OnCollisionStay2D(Collision2D collision) {
        
        if (collision.gameObject.CompareTag("Heroe"))
        {
            if (lastAttack >= 2)
            {
                // Han pasado dos segundos desde el último ataque
                // Tu código para atacar aquí
                lastAttack = 0; // Actualiza el tiempo del último ataque
                attack(dmg);
            }
        }
    }


    public void attack(int dmg){
        bool isAnimationPlaying = animator.GetCurrentAnimatorStateInfo(0).IsName("Hurt");

        if (!isAnimationPlaying){
            animator.Play("Attack");
            Debug.Log("Atacando");
        }
        
        
    }
}
