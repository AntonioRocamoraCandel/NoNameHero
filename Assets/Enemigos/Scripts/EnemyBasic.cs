using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBasic : MonoBehaviour
{
    public int heal,damage;
    public float velocidadMovimiento = 5f; // Velocidad del movimiento horizontal
    public float maxRange = 5f; // Distancia máxima de movimiento hacia la izquierda

    private float rightLimit, leftLimit;
    public GameObject target;

    private Rigidbody2D rb;
    private Vector2 movimiento;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Obtiene el componente Rigidbody2D del sprite
        rightLimit = transform.position.x + maxRange; // Limite de recorrido hacia la derecha
        leftLimit = transform.position.x - maxRange; // Limite de recorrido hacia la izquierda
        movimiento = Vector2.right * velocidadMovimiento; // Define el movimiento a la derecha como el vector de velocidad por defecto
        
    }
    void FixedUpdate() 
    {
        if(target != null){

            float distance = Mathf.Abs(transform.position.x - target.transform.position.x);

            if(distance <= 5){
                 // Calcula la nueva posición del sprite solo en el eje X
                Vector2 newPosition = new Vector2(target.transform.position.x, transform.position.y);
                // Mueve el sprite hacia la nueva posición
                transform.position = Vector2.MoveTowards(transform.position, newPosition, Time.deltaTime * velocidadMovimiento);
            }else{
                // Si el personaje ha llegado al límite izquierdo, cambia la dirección del movimiento a la derecha
                if(transform.position.x <= leftLimit)
                {
                    movimiento = Vector2.right * velocidadMovimiento;
                    transform.localScale = new Vector3(1f, 1f, 1f);
                }
                // Si el personaje ha llegado al límite derecho, cambia la dirección del movimiento a la izquierda
                else if(transform.position.x > rightLimit)
                {
                    movimiento = Vector2.left * velocidadMovimiento;
                    transform.localScale = new Vector3(-1f, 1f, 1f);
                }

                // Aplica el movimiento al Rigidbody2D
                rb.velocity = movimiento;

            }
            
        }
        
    }
        
}
