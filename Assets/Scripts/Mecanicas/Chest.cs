using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Chest : MonoBehaviour {
    Animator myAnim;
    public GameObject chestItems;
    public float chestDelay;
    bool opened = false;

    public int itemAmount;

    int ItemCount;

    void Start(){

        myAnim = GetComponent<Animator>();
    }

    private void OnTriggerStay2D(Collider2D other) {

        if(other.CompareTag("Heroe")) {
            if (InputSystem.GetDevice<Gamepad>() != null)
        {
            if (Gamepad.current.buttonWest.wasPressedThisFrame && opened == false)
            {
                myAnim.Play("Chest_open");
                StartCoroutine(GetChestItem());
            }
        }
        if (InputSystem.GetDevice<Keyboard>() != null )
        {
            if (Keyboard.current[Key.E].wasPressedThisFrame)
            {
                myAnim.Play("Chest_open");
                StartCoroutine(GetChestItem());
            }
        }
        }  
        
    }

    IEnumerator GetChestItem() {
        while(ItemCount < itemAmount)
        {
        opened = true;
        yield return new WaitForSeconds(chestDelay);
        Instantiate(chestItems, transform.position, Quaternion.identity);
        ItemCount++;
        }   
    }
}
