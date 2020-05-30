using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogueBoxButtons : MonoBehaviour
{

    public GameObject wizardShop;
    public GameObject dialogueBox;

    public GameObject UI;
    public GameObject ending;


    public void ShopButton()
    {
        wizardShop.SetActive(true);
        dialogueBox.SetActive(false);
    }

    public void ExitButton()
    {
        dialogueBox.SetActive(false);
        FindObjectOfType<Movement>().enabled = true;
        UI.SetActive(true);
        if(SceneManager.GetActiveScene().buildIndex == 5)
        {
            ending.SetActive(true);
        }
    }
}
