using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransicionEscena : MonoBehaviour
{
    public Animator animator;
    [SerializeField] public AnimationClip animacionFinal;

    private void Start(){
        animator = GetComponent<Animator>();
    }
}
