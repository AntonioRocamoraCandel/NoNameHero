using UnityEngine;
public class AttackControllerRange : MonoBehaviour

{
    public GameObject projectile;

    public int dmg;

    private float lastAttack;
    private Animator animator;
  
    void Awake()
    {
        animator = GetComponentInParent<Animator>();
    }
    void Start()
    {
        lastAttack = 0f;
    }

    
    void Update()
    {
        lastAttack = lastAttack + Time.deltaTime;
    }
    
    
    public void attack(GameObject target){
        if (lastAttack > 2)
        {
            bool isAnimationPlaying = animator.GetCurrentAnimatorStateInfo(0).IsName("Hurt");

            if (!isAnimationPlaying){
                animator.Play("Attack");
                shoot();
            }
            lastAttack = 0;
        }
    }
    
    public void shoot()
    {
        Vector2 shootPosition = new Vector2(transform.position.x,transform.position.y - 0.2f);
        GameObject rock = Instantiate(projectile, shootPosition, Quaternion.identity);
        if (transform.localScale.x < 0)
        {
            rock.GetComponent<Rigidbody2D>().AddForce(new Vector2(300f, 0f), ForceMode2D.Force);            
        }
        else
        {
            rock.GetComponent<Rigidbody2D>().AddForce(new Vector2(-300f, 0f), ForceMode2D.Force);
        }

    }
}
