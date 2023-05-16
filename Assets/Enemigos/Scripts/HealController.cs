using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealController : MonoBehaviour
    
{
    private Animator animator;
    public int heal;
    
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    
    void Update()
    {
       
    }

    public void getDamage(int dmg){
        heal = heal - dmg;
        animator.Play("Hurt");
        if (heal <= 0){
            Debug.Log("Muerto");
        }
    }
}
