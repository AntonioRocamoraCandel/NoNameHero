using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBasic : MonoBehaviour
{
   
    public float velocidadMovimiento = 5f; // Velocidad del movimiento horizontal
    public float maxRange = 5f; // Distancia máxima de movimiento hacia la izquierda

    private float rightLimit, leftLimit;
    public GameObject target;

    private Rigidbody2D rb;
    private Vector2 movimiento;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Obtiene el componente Rigidbody2D del sprite
        rightLimit = transform.position.x + maxRange; // 
        leftLimit = transform.position.x - maxRange;
        movimiento = Vector2.right * velocidadMovimiento; // Define el movimiento a la derecha como el vector de velocidad por defecto
    }

    void FixedUpdate() 
    {
        // Si el personaje ha llegado al límite izquierdo, cambia la dirección del movimiento a la derecha
        if(transform.position.x <= leftLimit)
        {
            Debug.Log("hola");
            movimiento = Vector2.right * velocidadMovimiento;
        }
        // Si el personaje ha llegado al límite derecho, cambia la dirección del movimiento a la izquierda
        else if(transform.position.x > rightLimit)
        {
            movimiento = Vector2.left * velocidadMovimiento;
        }

        // Aplica el movimiento al Rigidbody2D
        rb.velocity = movimiento;
    }
        
}
