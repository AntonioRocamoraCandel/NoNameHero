using UnityEngine;
using UnityEngine.Tilemaps;

public class CambiarTilemap : MonoBehaviour
{
    public Tilemap tilemap;
    public TilemapRenderer tilemapRenderer;
    public TilemapCollider2D tilemapCollider;

    public HealController healController;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Heroe"))
        {
            tilemap.enabled = true;
            tilemapRenderer.enabled = true;
            tilemapCollider.isTrigger = false;
            
        }
    }
    public void EnemyDeath()
    {
            tilemap.enabled = false;
            tilemapRenderer.enabled = false;
            tilemapCollider.isTrigger = true;
    }
}