using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueBoxButtons : MonoBehaviour
{

    public GameObject wizardShop;
    public GameObject dialogueBox;

    public GameObject UI;


    public void ShopButton()
    {
        wizardShop.SetActive(true);
        dialogueBox.SetActive(false);
    }

    public void ExitButton()
    {
        dialogueBox.SetActive(false);
        FindObjectOfType<Movement>().lockMovement = false;
        UI.SetActive(true);
    }
}
