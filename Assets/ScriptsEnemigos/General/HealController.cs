using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealController : MonoBehaviour

{
    private Animator animator;
    public int heal;

    private float attackDelay = 0.0f;

    public bool isDeath = false;

    void Start()
    {
        animator = GetComponent<Animator>();
    }


    void Update()
    {
        attackDelay = attackDelay + Time.deltaTime;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("PiedraHeroe"))
        {

            getDamage(25);
        }

    }

    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("MagiaHeroe"))
        {

            getDamage(75);
        }

    }

    void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("attackCheck"))
        {
            //getDamage(25);
            GameObject parentObject = collision.gameObject.transform.parent.gameObject;

            Animator heroeAnimator = parentObject.GetComponent<Animator>();
            AnimatorStateInfo stateInfo = heroeAnimator.GetCurrentAnimatorStateInfo(0);

            // Comprobar si la animación "golpe" se está reproduciendo
            if (stateInfo.IsName("hero-attack"))
            {
                Debug.Log("Recibo daño");
                getDamage(25);
            }

        }

    }


    public void getDamage(int dmg)
    {
        if (attackDelay > 0.5f){
            attackDelay = 0;
            heal = heal - dmg;

            if (heal <= 0)
            {
                PlayDeathAnimation();
            }
            else
            {
                animator.Play("Hurt");
            }
        }
        
    }

    public void PlayDeathAnimation()
    {
        isDeath = true;
        StartCoroutine(PlayDeathAnimationCoroutine());
    }

    private IEnumerator PlayDeathAnimationCoroutine()
    {
        // Inicia la animación
        animator.Play("Death");

        // Espera hasta que la animación termine (tiempo normalizado >= 1.0f)
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);

        // La animación ha terminado, destruye el GameObject
        Destroy(gameObject);
    }


}
