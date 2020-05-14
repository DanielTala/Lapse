using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopButtons : MonoBehaviour
{
    public GameObject weapons;
    public GameObject consumables;
    
    public Button weaponsButton;
    public Button consumablesButton;
    
    private bool weaponsActive = true;
    private bool consumablesActive = false;

    void Start()
    {
        weaponsButton.interactable = false;
        consumablesButton.interactable = true;
    }

    void Update()
    {
        if (weaponsActive && !consumablesActive)
        {
            //then weapons button is not interactable
            weaponsButton.interactable = false;
            consumablesButton.interactable = true;
        }
        else if (!weaponsActive && consumablesActive)
        {
            //then consumables is not interactable
            consumablesButton.interactable = false;
            weaponsButton.interactable = true;
        }
    }

    public void WeaponsClicked()
    {
        consumables.SetActive(false);
        weapons.SetActive(true);
        weaponsActive = true;
        consumablesActive = false;
    }

    public void ConsumablesClicked()
    {
        weapons.SetActive(false);
        consumables.SetActive(true);
        weaponsActive = false;
        consumablesActive = true;
    }
}
