using UnityEngine;

public class EnemyBasic : MonoBehaviour
{
    public float velocidadMovimiento = 5f; // Velocidad del movimiento horizontal
    public float maxRange = 5f; // Distancia máxima de movimiento hacia la izquierda

    private float rightLimit, leftLimit; // Maxima distancia que recorre de izquierda a derecha
    public GameObject target; // Target que se busca

    private Rigidbody2D rb;
    private Vector2 movimiento;

    // Exclamación
    public GameObject spriteObject;

    // Variable que dirá si se ha detectado o no al enemigo, para realizar solo la detección cuando lo ha visto después de perderlo de vista
    bool isDetected = false;

    //Detectar
    bool isCollision = false;

    // Animator 
    private Animator animator;
    void Start()
    {   
        rb = GetComponent<Rigidbody2D>(); // Obtiene el componente Rigidbody2D del sprite
        rightLimit = transform.position.x + maxRange; // Limite de recorrido hacia la derecha
        leftLimit = transform.position.x - maxRange; // Limite de recorrido hacia la izquierda
        movimiento = Vector2.right * velocidadMovimiento; // Define el movimiento a la derecha como el vector de velocidad por defecto
        animator = GetComponent<Animator>();
    }
    void FixedUpdate() 
    {
        animator.SetBool("isColliding", isCollision);
        if(target != null || !isCollision){

            float distance = Mathf.Abs(transform.position.x - target.transform.position.x);
            
            if(distance <= 5){
                if (isDetected == false){
                    EnemyDetection spriteVisibility = spriteObject.GetComponent<EnemyDetection>();
                    spriteVisibility.MakeSpriteVisible();
                }

                isDetected = true;
                
                 // Calcula la nueva posición del sprite solo en el eje X
                
                if(target.transform.position.x > transform.position.x){
                    transform.localScale = new Vector3(-1f, 1f, 1f);
                }else{
                    transform.localScale = new Vector3(1f, 1f, 1f);
                }

                Vector2 newPosition = new Vector2(target.transform.position.x, transform.position.y);
                // Mueve el sprite hacia la nueva posición
                transform.position = Vector2.MoveTowards(transform.position, newPosition, Time.deltaTime * velocidadMovimiento);
            }else{
                isDetected = false;
                Debug.Log(transform.position.x + " Left " + leftLimit);
                Debug.Log(transform.position.x + " Right " + leftLimit);
                // Si el personaje ha llegado al límite izquierdo, cambia la dirección del movimiento a la derecha
                if(transform.position.x <= leftLimit)
                {
                    Debug.Log("hola");
                    transform.localScale = new Vector3(-1f, 1f, 1f);
                    movimiento = Vector2.right * velocidadMovimiento;
                    
                // Si el personaje ha llegado al límite derecho, cambia la dirección del movimiento a la izquierda
                }else if(transform.position.x > rightLimit)
                {
                    Debug.Log("hola");
                    transform.localScale = new Vector3(1f, 1f, 1f);
                    movimiento = Vector2.left * velocidadMovimiento;
                    
                }

                // Aplica el movimiento al Rigidbody2D
                rb.velocity = movimiento;
                 
            }
            
        }
        
    }

    
    void OnCollisionStay2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Heroe"))
        {
            isCollision = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Heroe"))
        {
            isCollision = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
{
    if (collision.gameObject.CompareTag("Enemigo"))
    {
        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), collision.collider);
    }
}
    
  
}
