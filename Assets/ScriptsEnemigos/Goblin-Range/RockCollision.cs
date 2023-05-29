
using UnityEngine;

namespace ScriptsEnemigos.Goblin_Range
{
    public class RockCollision : MonoBehaviour
    {
        public string objectiveTag; 
        public float timeToDestroy = 3f; 

        private bool collision = false;
        private float timeElapsed = 0f;

        void Update()
        {
            if (!collision)
            {
                timeElapsed += Time.deltaTime;
                if (timeElapsed >= timeToDestroy)
                {
                    RockDestroy();
                }
            }
        }

        void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(objectiveTag))
            {
                Damage(other.gameObject);
                RockDestroy();
            }
        }

        void Damage(GameObject objeto)
        {
            // Lógica para hacer daño al objeto con el que colisionó la roca
            // ...
        }

        void RockDestroy()
        {
            collision = true;
            Destroy(gameObject);
        }
    }
}