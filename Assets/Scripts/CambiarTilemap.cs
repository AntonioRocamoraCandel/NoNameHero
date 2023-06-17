using UnityEngine;
using UnityEngine.Tilemaps;

public class CambiarTilemap : MonoBehaviour
{
    public Tilemap tilemap;
    public TilemapRenderer tilemapRenderer;
    public TilemapCollider2D tilemapCollider;

    private bool isParedHabilitada = true;
    private bool isColliderTrigger = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Heroe"))
        {
            tilemap.enabled = true;
            tilemapRenderer.enabled = true;
            tilemapCollider.isTrigger = false;
            isParedHabilitada = true;
            
        }
    }
}