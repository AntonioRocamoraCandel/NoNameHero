using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPause : MonoBehaviour
{
 
    public void pause()
    {
        Time.timeScale = 0f;
    }
    public void reanudar()
    {
        Time.timeScale = 1f;
    }

    public void reiniciar (){
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
    public void salirPantallaInicio (){
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }
}
