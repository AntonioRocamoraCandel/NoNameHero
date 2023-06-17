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

    //Detectar Collisiones con Heroe y Obstaculos
    bool isCollision = false;

    bool isDerecha = true;

    bool isObstacle = false;

    float timeObstacle = 0.0f;

    float rotationDelay = 0.0f;

    // Animator 
    private Animator animator;

    public GameManager gameManager;

    
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

        rotationDelay = rotationDelay + Time.deltaTime;


        timeObstacle = timeObstacle + Time.deltaTime;

        if(isObstacle){
            timeObstacle = 0.0f;
        }

        animator.SetBool("isColliding", isCollision);
        if (!gameManager.estaMuerto && !GetComponent<HealController>().isDeath){
            if(!isCollision){

                float distance = Mathf.Abs(transform.position.x - target.transform.position.x);
                
                if (distance <= 5 && timeObstacle > 1.5f)
                {
                    if (isDetected == false)
                    {
                        EnemyDetection spriteVisibility = spriteObject.GetComponent<EnemyDetection>();
                        spriteVisibility.MakeSpriteVisible();
                    }

                    isDetected = true;

                    Vector2 newPosition;

                    // Calcula la nueva posición del sprite solo en el eje X
                    if (target.transform.position.x > transform.position.x)
                    {
                        transform.localScale = new Vector3(-1f, 1f, 1f);
                        newPosition = new Vector2(target.transform.position.x - 0.3f, transform.position.y);
                    }
                    else
                    {
                        transform.localScale = new Vector3(1f, 1f, 1f);
                        newPosition = new Vector2(target.transform.position.x + 0.3f, transform.position.y);
                    }
                    
                    transform.position = Vector2.MoveTowards(transform.position, newPosition, Time.deltaTime * velocidadMovimiento);
                    
                }
                else
                {
                    Vector2 newPosition;

                    isDetected = false;
                    // Si el personaje ha llegado al límite izquierdo, cambia la dirección del movimiento a la derecha
                    if (isDerecha)
                    {
                        transform.localScale = new Vector3(-1f, 1f, 1f);
                        newPosition = new Vector2(transform.position.x+1,transform.position.y);  
                    }else
                    {
                        transform.localScale = new Vector3(1f, 1f, 1f);
                        newPosition = new Vector2(transform.position.x-1,transform.position.y);
                    }
                    transform.position = Vector2.MoveTowards(transform.position, newPosition, Time.deltaTime * velocidadMovimiento);
                
                }
            }
        }
        
    }

    void OnTriggerStay2D(Collider2D collision){
         if (collision.gameObject.CompareTag("HealArea"))
        {
            isCollision = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision){
         if (collision.gameObject.CompareTag("HealArea"))
        {
            isCollision = false;
        }
    }

    void OnTriggerEnter2D(Collider2D collision){
         if (collision.gameObject.CompareTag("HealArea"))
        {
            isCollision = true;
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        
            if (collision.gameObject.CompareTag("obstacle")){
                if (rotationDelay > 0.5){
                    isDerecha = !isDerecha;
                    rotationDelay = 0;
                    isObstacle = true;
                }
                
            }    
    }



    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("obstacle"))
        {
            isObstacle = false;
        }

    }

 
    void OnCollisionEnter2D(Collision2D collision)
    {   

        if (collision.gameObject.CompareTag("Enemigo") || collision.gameObject.CompareTag("Heroe"))
        {
            if (collision.gameObject.CompareTag("Heroe")){
                isCollision = true;
            }

            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), collision.collider);
        }

        if (collision.gameObject.CompareTag("obstacle")){
            if (rotationDelay > 0.5){
                isDerecha = !isDerecha;
                rotationDelay = 0;
                isObstacle = true;
            }
                
        }   

    }
    
  
}
