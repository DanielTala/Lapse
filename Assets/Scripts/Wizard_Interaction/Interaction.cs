using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{

    
    public Transform boxSpawn;

    public GameObject dialogueBox;
    public GameObject shopButton;
    public GameObject exitButton;
    public GameObject nextButton;
    public GameObject welcomeMessage;
    public GameObject UI;

    public Dialogue dialogue;
   
    private bool dialogueBoxIsActive = false;
    private bool playerInRange = false;

    void Update()
    {
       
        if (!dialogueBoxIsActive && playerInRange && Input.GetButtonDown("Interact"))
        {
            dialogueBox.SetActive(true);
            dialogueBoxIsActive = true;
            welcomeMessage.SetActive(false);
            TriggerDialogue();
            if (FindObjectOfType<Combat>().selectedWeapon == Combat.weapons.None)
                FindObjectOfType<Combat>().WeaponSelect(1);
            FindObjectOfType<Movement>().lockMovement = true;
            FindObjectOfType<Movement>().GetComponent<Animator>().SetInteger("state", 0);
            UI.SetActive(false);
        }

        if (dialogueBoxIsActive)
        {
            dialogueBoxIsActive = false;
        }

        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            playerInRange = false;          
        }
    }


    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    
}
