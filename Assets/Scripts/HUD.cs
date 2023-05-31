using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUD : MonoBehaviour
{
	public GameObject[] vidas;
    
	void Update () {
		
	}

	public void DesactivarVida(int indice) {
		vidas[indice].SetActive(false);
	}

    public void DesactivarVidas() {
		vidas[0].SetActive(false);
        vidas[1].SetActive(false);
        vidas[2].SetActive(false);
	}

	public void ActivarVida(int indice) {
		vidas[indice].SetActive(true);
	}
}