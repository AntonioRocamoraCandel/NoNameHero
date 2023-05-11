using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigos : MonoBehaviour
{
    [SerializeField] private float vida;

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator= GetComponent<Animator>();
    }

    public void TomarDanyo(float danyo){
        vida -= danyo;

        if( vida <=0){
            Muerte();
        }
    }

    private void Muerte(){
        animator.SetTrigger("Muerte");
    }
}
