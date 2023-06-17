using UnityEngine;
using System;
using UnityEngine.Tilemaps;

public class CambiarTilemap : MonoBehaviour
{
    public Tilemap tilemap;
    public TilemapRenderer tilemapRenderer;
    public TilemapCollider2D tilemapCollider;

    public HealController healController;

    void Update()
    {
        try{
            EnemyDeath();
        }
        catch (NullReferenceException e){
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Heroe"))
        {
            tilemap.enabled = true;
            tilemapRenderer.enabled = true;
            tilemapCollider.isTrigger = false;
            GameObject tilemapGameObject = tilemap.gameObject;
            tilemapGameObject.tag = "wall";
            tilemapGameObject.layer = LayerMask.NameToLayer("wall");;
            
        }
    }
    public void EnemyDeath()
    {   if(healController.isDeath){
            tilemap.enabled = false;
            tilemapRenderer.enabled = false;
            tilemapCollider.isTrigger = true;
            GameObject tilemapGameObject = tilemap.gameObject;
            tilemapGameObject.tag = "Untagged";
            tilemapGameObject.layer = LayerMask.NameToLayer("Default");;
    }
    }
}