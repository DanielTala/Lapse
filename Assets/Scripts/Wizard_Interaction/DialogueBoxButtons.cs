using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueBoxButtons : MonoBehaviour
{

    public GameObject wizardShop;
    public GameObject dialogueBox;

    public GameObject shopButton;
    public GameObject exitButton;
    public GameObject nextButton;
    public GameObject UI;


    public void ShopButton()
    {
        wizardShop.SetActive(true);
        dialogueBox.SetActive(false);
        shopButton.SetActive(false);
        exitButton.SetActive(false);
        nextButton.SetActive(true);
    }

    public void ExitButton()
    {
        dialogueBox.SetActive(false);
        shopButton.SetActive(false);
        exitButton.SetActive(false);
        nextButton.SetActive(true);
        FindObjectOfType<Movement>().lockMovement = false;
        UI.SetActive(true);
    }
}
