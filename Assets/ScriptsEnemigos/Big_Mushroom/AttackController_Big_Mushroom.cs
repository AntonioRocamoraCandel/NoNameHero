using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackController_Big_Mushroom : MonoBehaviour
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


    void OnTriggerStay2D(Collider2D collider)
    {
        Debug.Log(collider.gameObject.tag);
        
        if (collider.gameObject.CompareTag("HealArea"))
        {
            if (lastAttack >= 2)
            {
                // Han pasado dos segundos desde el último ataque
                // Tu código para atacar aquí
                lastAttack = 0; // Actualiza el tiempo del último ataque
                attack();
            }
        }
    }


    
    public void attack(){
        GameManager.Instance.PerderVida();
    }
}
