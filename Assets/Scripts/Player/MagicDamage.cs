using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicDamage : MonoBehaviour
{
    public string objectiveTag; 
        public float timeToDestroy = 1.5f; 

        private bool collision = false;
        private float timeElapsed = 0f;

        void Update()
        {
            if (!collision)
            {
                timeElapsed += Time.deltaTime;
                if (timeElapsed >= timeToDestroy)
                {
                    Destroy(gameObject);
                }
            }
        }


        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag(objectiveTag))
            {
                Destroy(gameObject); // Destruye la bala actual
                Damage(collision.gameObject); // Destruye el objeto con la etiqueta "ObjetoDestruible"
                
                // Realizar otras acciones adicionales aquí si es necesario
            }
        }

        


        void Damage(GameObject objeto)
        {
            // Lógica para hacer daño al objeto con el que colisionó la roca
            // ...
        }
}
