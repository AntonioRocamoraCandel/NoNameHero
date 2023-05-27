using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCtroller_Big_Mushroom : MonoBehaviour
{
     private float lastAttack;
     public int dmg;


     void Start()
    {
        lastAttack = 0f;
    }

    void Update()
    {
        lastAttack = lastAttack + Time.deltaTime;
    }


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
        // Seria acceder al script del target y lanzar el metodo recibir daño enviandole nuestro dmg
        Debug.Log("Atacando big mushrom");
    }
}
