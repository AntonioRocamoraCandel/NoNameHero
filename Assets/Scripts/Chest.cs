using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour {
    Animator myAnim;
    public GameObject chestItems;
    public float chestDelay;

    void Start(){

        myAnim = GetComponent<Animator>();
    }

    private void OnTriggerStay2D(Collider2D other) {

        if(other.CompareTag("Player")) {

            if(Input.GetKeyDown(KeyCode.E)) {

                myAnim.Play("chest_open");
                StartCoroutine(GetChestItem());
            }
        }  
    }
    IEnumerator GetChestItem() {
        yield return new WaitForSeconds(chestDelay);
        Instantiate(chestItems, transform.position, Quaternion.identity);
    }
}
