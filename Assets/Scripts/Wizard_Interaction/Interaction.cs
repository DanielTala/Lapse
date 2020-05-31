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
    public GameObject wizardImage;
    public GameObject wizardImageNormal;
    public Movement mov;


    public Dialogue dialogue;
   
    private bool dialogueBoxIsActive = false;
    private bool playerInRange = false;

    void Update()
    {
       
        if (!dialogueBoxIsActive && playerInRange && Input.GetButtonDown("Interact"))
        {
            mov.lockMovement = true;
            FindObjectOfType<DialogueManager>().interacted = true;
            dialogueBox.SetActive(true);
            dialogueBoxIsActive = true;
            TriggerDialogue();
            if (welcomeMessage)
            welcomeMessage.SetActive(false);
            if (FindObjectOfType<DisplayText>())
                FindObjectOfType<DisplayText>().gameObject.SetActive(false);
            if (FindObjectOfType<Combat>().selectedWeapon == Combat.weapons.None)
                FindObjectOfType<Combat>().WeaponSelect(1);
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
