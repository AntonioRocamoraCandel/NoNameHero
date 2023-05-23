using System.Collections;
using System.Collections.Generic;
using Mono.Cecil.Rocks;
using Unity.VisualScripting;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public GameObject projectile;

    public float timeToShoot;
    public float shootCooldown;

    public bool detectHeroe;
    // Start is called before the first frame update
    void Start()
    {
        shootCooldown = timeToShoot;
    }

    // Update is called once per frame
    void Update()
    {
        if(shootCooldown < 0){
            shoot();
        }
        
    }

    public void shoot()
    {
        GameObject rock = Instantiate(projectile, transform.position, Quaternion.identity);
        if (transform.localScale.x < 0)
        {
            rock.GetComponent<Rigidbody2D>().AddForce(new Vector2(300f, 0f), ForceMode2D.Force);            
        }
        else
        {
            rock.GetComponent<Rigidbody2D>().AddForce(new Vector2(-300f, 0f), ForceMode2D.Force);
        }

        shootCooldown = timeToShoot;
    }
}
