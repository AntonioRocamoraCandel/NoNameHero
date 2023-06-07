using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public HUD hud;

    public PlayerMovement playerMovement;

    private int vidas = 3;
    private float tiempoRecuperacion = 20f;
    private float tiempoPasado = 0f;
    private bool reinicioPendiente = false;
    public float tiempoEspera = 1.5f;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.Log("Cuidado! Mas de un GameManager en escena.");
        }
    }

    private void Update()
    {
        tiempoPasado += Time.deltaTime;

        if (tiempoPasado >= tiempoRecuperacion && vidas < 3)
        {
            RecuperarVida();
        }
    }

    public void PerderVida()
    {
        vidas -= 1;

        if (vidas == 0)
        {
            SceneManager.LoadScene("SceneLevel2");
        }

        hud.DesactivarVida(vidas);
    }

    public bool RecuperarVida()
    {
        if (vidas == 3)
        {
            return false;
        }

        hud.ActivarVida(vidas);
        vidas += 1;
        tiempoPasado = 0f;
        return true;
    }

    public void PerderVidas(int cantidad)
    {
        vidas -= cantidad;

        if (vidas <= 0)
        {
            vidas = 0;
            if (playerMovement != null && playerMovement.animator != null)
        {
            playerMovement.animator.SetBool("death", true);
        }
            StartCoroutine(EsperarYReiniciar(tiempoEspera));
        }

        hud.DesactivarVidas();
    }
    private IEnumerator EsperarYReiniciar(float tiempo)
    {
        yield return new WaitForSeconds(tiempo);
        SceneManager.LoadScene("SceneLevel2");
    }

}