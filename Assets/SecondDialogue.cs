using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondDialogue : MonoBehaviour
{
    public Dialogue dialogue2;

    public Transform boxSpawn;

    public GameObject dialogueBox;
    public GameObject shopButton;
    public GameObject exitButton;
    public GameObject nextButton;
    public GameObject UI;

    public Movement mov;


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
        FindObjectOfType<DialogueManager2>().StartDialogue(dialogue2);
    }

}
