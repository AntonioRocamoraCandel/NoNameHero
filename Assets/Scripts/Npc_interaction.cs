using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Npc_interaction : MonoBehaviour
{
    public GameObject dialoguePanel;
    public Text dialogueText;
    public Text NpcNameText;
    public string[] dialogue;
    public string NpcName;
    private int index;
    
    public float wordSpeed;
    public bool playerIsClose;

    void Start()
    {
        NpcNameText.text = NpcName;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && playerIsClose)
        {
            if (dialoguePanel.activeInHierarchy)
            {
                zeroText();
            }
            else
            {
                dialogueText.text = "";
                dialoguePanel.SetActive(true);
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
    }

    public void NextLine()
    {
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
    }
}
