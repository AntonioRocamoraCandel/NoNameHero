using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_Actions : MonoBehaviour
{
    public TransicionEscena transicionEscena;
    public void Jugar()
    {
        VariablesGlobales.currentIndex=0;
        StartCoroutine(CambiarEscena());

    }

    public void Salir()
    {
        Debug.Log("Salir...");
        VariablesGlobales.currentIndex=0;
        Application.Quit();
    }

    IEnumerator CambiarEscena(){
        transicionEscena.animator.SetTrigger("Iniciar");

        yield return new WaitForSeconds(transicionEscena.animacionFinal.length);
        SceneManager.LoadScene("City");
    }
}
