using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Npc_interaction : MonoBehaviour
{
    public GameObject dialoguePanel;
    public TextMeshProUGUI dialogueText;
    public TextMeshProUGUI NpcNameText;
    public string NpcName;
    public GameObject interrogacion;
    public GameObject buttonContinue;
    public float wordSpeed;
    public bool playerIsClose;
    public string pasoCiudad;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        if (playerIsClose)
        {
            interrogacion.SetActive(true);
        }
        else
        {
            interrogacion.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.E) && playerIsClose)
        {
            if (dialoguePanel.activeInHierarchy)
            {
                zeroText();
            }
            else
            {
                buttonContinue.SetActive(false);
                dialogueText.text = "";
                dialoguePanel.SetActive(true);
                NpcNameText.text = NpcName;
                StartCoroutine(Typing());
            }
        }
    }
    
    public void zeroText()
    {
        dialogueText.text = "";
        dialoguePanel.SetActive(false);
    }

    IEnumerator Typing()
    {   
        DialogosNpcs dialogosNpcs = GetComponent<DialogosNpcs>();
        string dialogue = dialogosNpcs.FindDialogueByPositions(NpcName, pasoCiudad);
        if (dialogue != null)
        {
            foreach (char letter in dialogue.ToCharArray())
            {
                dialogueText.text += letter;
                yield return new WaitForSeconds(wordSpeed);
            }
        }
        buttonContinue.SetActive(true);
    }

    public void NextLine()
    {   
        zeroText();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Heroe"))
        {
            playerIsClose = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Heroe"))
        {
            playerIsClose = false;
            zeroText();
        }
    }
}
