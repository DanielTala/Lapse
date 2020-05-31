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
    public Movement mov;


    public void ShopButton()
    {
        wizardShop.SetActive(true);
        dialogueBox.SetActive(false);
    }

    public void ExitButton()
    {
        dialogueBox.SetActive(false);
        mov.lockMovement = false;
        UI.SetActive(true);
        if(SceneManager.GetActiveScene().buildIndex == 5)
        {
            ending.SetActive(true);
        }
    }
}
