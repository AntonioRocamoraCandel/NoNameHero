using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_Actions : MonoBehaviour
{
    public void Jugar()
    {
        SceneManager.LoadScene("City");
    }

    public void Salir()
    {
        Debug.Log("Salir...");
        Application.Quit();
    }
}
