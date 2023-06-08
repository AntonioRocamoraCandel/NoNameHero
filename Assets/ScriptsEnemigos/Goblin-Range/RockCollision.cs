
using UnityEngine;

namespace ScriptsEnemigos.Goblin_Range
{
    public class RockCollision : MonoBehaviour
    {   
        public int dmg=1;
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


        private void OnTriggerEnter2D(Collider2D other) {
            if (other.CompareTag(objectiveTag))
            {
                Damage(other.gameObject);
                RockDestroy();
            }
        }

        


        void Damage(GameObject objeto)
        {
            GameManager.Instance.PerderVidas(dmg);
        }

        void RockDestroy()
        {
            collision = true;
            Destroy(gameObject);
        }
    }
}