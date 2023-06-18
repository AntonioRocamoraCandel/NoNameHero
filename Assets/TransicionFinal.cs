using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransicionFinal : MonoBehaviour
{
    public TransicionEscena transicionEscena;
    // Start is called before the first frame update
    public void terminar()
    {
        StartCoroutine(CambiarEscena());
        //Que aparezca el canvas
    }

    IEnumerator CambiarEscena(){
        transicionEscena.animator.SetTrigger("Iniciar");

        yield return new WaitForSeconds(transicionEscena.animacionFinal.length);
    }
}
