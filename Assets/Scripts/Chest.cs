using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour {
    Animator myAnim;
    public GameObject chestItems;
    public float chestDelay;
    bool opened = false;

    void Start(){

        myAnim = GetComponent<Animator>();
    }

    private void OnTriggerStay2D(Collider2D other) {

        if(other.CompareTag("Player")) {

            if(Input.GetKeyDown(KeyCode.E) && opened == false) {

                myAnim.Play("Chest_open");
                StartCoroutine(GetChestItem());
            }
        }  
    }
    IEnumerator GetChestItem() {
        opened = true;
        yield return new WaitForSeconds(chestDelay);
        Instantiate(chestItems, transform.position, Quaternion.identity);
    }
}
