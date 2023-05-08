using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetection : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void MakeSpriteVisible()
    {
        StartCoroutine(VisibleForTwoSeconds());
    }

    IEnumerator VisibleForTwoSeconds()
    {
        // Hacer visible el sprite
        spriteRenderer.color = new Color(1f, 1f, 1f, 1f);

        // Esperar 2 segundos
        yield return new WaitForSeconds(2f);

        // Hacer el sprite transparente
        spriteRenderer.color = new Color(1f, 1f, 1f, 0f);
    }
}
