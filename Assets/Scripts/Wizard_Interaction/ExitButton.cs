using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitButton : MonoBehaviour
{

    public GameObject wizardShop;
    public GameObject UI;

    public void ExitShop()
    {
        wizardShop.SetActive(false);
        FindObjectOfType<Movement>().lockMovement = false;
        UI.SetActive(true);
    }
}
