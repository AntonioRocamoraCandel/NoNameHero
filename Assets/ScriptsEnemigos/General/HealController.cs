using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealController : MonoBehaviour
    
{
    private Animator animator;
    public int heal;
    
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    
    void Update()
    {
       
    }

    void OnCollisionStay2D(Collision2D collision){
        
        
            if (collision.gameObject.CompareTag("PiedraHeroe"))
            {
           
                getDamage(25);
            }
        
    }
    
    void OnTriggerStay2D(Collider2D collision){
        
        
            if (collision.gameObject.CompareTag("MagiaHeroe"))
            {
           
                getDamage(75);
            }
        
    }
    

    

    public void getDamage(int dmg){
        heal = heal - dmg;
        Debug.Log("Authc");
        
        if (heal <= 0){
            StartCoroutine(getDeath());
        }else{
            animator.Play("Hurt");
        }
    }

    IEnumerator getDeath()
    {
        animator.Play("Death"); // Inicia la animación

        // Espera hasta que la animación termine
        while (animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1f)
        {
            yield return null;
        }

        // La animación ha terminado, destruye el GameObject
        Destroy(gameObject);
    }
    
}
