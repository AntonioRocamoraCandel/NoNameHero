using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class Npc_interaction : MonoBehaviour
{
    public GameObject dialoguePanel;
    public TextMeshProUGUI dialogueText;
    public TextMeshProUGUI NpcNameText;
    public string[] dialogue;
    public string NpcName;
    private int index;
    public GameObject interrogacion;
    public GameObject buttonContinue;
    public float wordSpeed;
    public bool playerIsClose;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {   
        if(playerIsClose)
        {
            interrogacion.SetActive(true);
        }
        else
        {
            interrogacion.SetActive(false);
        }


        if(Input.GetKeyDown(KeyCode.E) && playerIsClose)
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
                NpcNameText.text = "";
                NpcNameText.text = NpcName;
                StartCoroutine(Typing());
            }
        }
    }
    
    public void zeroText()
    {
        dialogueText.text = "";
        index = 0;
        dialoguePanel.SetActive(false);
    }

    IEnumerator Typing()
    {
        foreach(char letter in dialogue[index].ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(wordSpeed);
        }
        buttonContinue.SetActive(true);
    }

    public void NextLine()
    {   
        buttonContinue.SetActive(false);
        if(index < dialogue.Length -1)
        {
            index++;
            dialogueText.text = "";
            StartCoroutine(Typing());
        }
        else
        {
            zeroText();
        }
    }
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
            playerIsClose = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
            playerIsClose = false;
            zeroText();
            Array.Clear(dialogue, 0, dialogue.Length);
    }
}
