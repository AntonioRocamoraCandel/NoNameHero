using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key_Destroy : MonoBehaviour
{

    public Inventory inventory;
    // Start is called before the first frame update
    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Heroe").GetComponent<Inventory>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Heroe")
        {
            inventory.white_Key = true;
            Destroy(gameObject);
        }
    }
}