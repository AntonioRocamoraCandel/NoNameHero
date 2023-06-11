using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public HUD hud;

    public PlayerMovement playerMovement;

    public int vidas = 3;
    private float tiempoRecuperacion = 20f;
    private float tiempoPasado = 0f;
    public float tiempoEspera = 0.5f;
    public bool sePuedeMover = true;
    public Vector2 velocidadRebote = new Vector2(20, 10);
    public float tiempoPerdidaControl=0f;

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
        hud.DesactivarVida(vidas);
        if (vidas == 0)
        {
            if (playerMovement != null && playerMovement.animator != null)
            {
                playerMovement.animator.SetBool("isDeath", true);
                playerMovement.animator.SetTrigger("death");
            }
            StartCoroutine(EsperarYReiniciar(tiempoEspera));
        }else if (playerMovement != null && playerMovement.animator != null)
        {
            playerMovement.animator.SetTrigger("hurt");
            StartCoroutine(PerderControl());
            Rebote(velocidadRebote);
        }

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
        hud.DesactivarVidas();
        if (vidas <= 0)
        {
            vidas = 0;
            if (playerMovement != null && playerMovement.animator != null)
        {
            playerMovement.animator.SetBool("isDeath", true);
            playerMovement.animator.SetTrigger("death");
        }
            StartCoroutine(EsperarYReiniciar(tiempoEspera));
        }
    }

    public void Rebote(Vector2 puntoGolpe){
        playerMovement.rb.velocity = new Vector2(-velocidadRebote.x, velocidadRebote.y);
    }

    private IEnumerator EsperarYReiniciar(float tiempo)
    {
        yield return new WaitForSeconds(tiempo);
        playerMovement.DestruirProtagonista();
        SceneManager.LoadScene("SceneLevel2");
    }

    private IEnumerator PerderControl(){
        sePuedeMover=false;
        yield return new WaitForSeconds(tiempoPerdidaControl);
        sePuedeMover=true;
    }

}