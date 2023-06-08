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
		for (int i = 0; i < vidas.Length; i++)
    {
        vidas[i].SetActive(false);
    }
	}

	public void ActivarVida(int indice) {
		vidas[indice].SetActive(true);
	}
}