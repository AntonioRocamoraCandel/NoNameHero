using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealController : MonoBehaviour

{
    public int heal;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public void getDamage(int dmg){
        heal = heal - dmg;

        if (heal <= 0){
            Debug.Log("Muerto");
        }
    }
}
