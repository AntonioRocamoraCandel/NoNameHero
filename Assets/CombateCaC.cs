using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombateCaC : MonoBehaviour
{
    [SerializeField] private Transform controladorGolpe;
    [SerializeField] private float radioGolpe;
    [SerializeField] private float danyoGolpe;

    private Animator animator;

    private void Start(){
        animator = GetComponent<Animator>();
    }

    private void update(){
        if (Input.GetButtonDown("Fire1")){
            Golpe();
        }
    }

    private void Golpe(){

        animator.SetTrigger("Attack");

        Collider2D[] objetos = Physics2D.OverlapCircleAll(controladorGolpe.position, radioGolpe);

        foreach (Collider2D colisionador in objetos)
        {
            if (colisionador.CompareTag("Enemigos")){
                colisionador.transform.GetComponent<Enemigos>().TomarDanyo(danyoGolpe);
            }
        }
    }


    private void onDrawGizmos(){
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(controladorGolpe.position, radioGolpe);
    }
}
