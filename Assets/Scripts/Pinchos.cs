using UnityEngine;

public class Pinchos : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other) {
		if(other.gameObject.CompareTag("Heroe")) {
			GameManager.Instance.PerderVidas(3);
		}
	}
}
