using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_Actions : MonoBehaviour
{
    public TransicionEscena transicionEscena;
    public void Jugar()
    {
        StartCoroutine(CambiarEscena());
    }

    public void Salir()
    {
        Debug.Log("Salir...");
        Application.Quit();
    }

    IEnumerator CambiarEscena(){
        transicionEscena.animator.SetTrigger("Iniciar");

        yield return new WaitForSeconds(transicionEscena.animacionFinal.length);
        SceneManager.LoadScene("City");
    }
}
