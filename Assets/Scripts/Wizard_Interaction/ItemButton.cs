using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemButton : MonoBehaviour
{

    public GameObject weaponsInfo;
    public GameObject consumablesInfo;

    public void WeaponClicked()
    {
        weaponsInfo.SetActive(true);
    }
    
    public void WeaponPurchase()
    {
        Debug.Log("Weapon has been purchased!");
    }

    public void WeaponCancel()
    {       
        weaponsInfo.SetActive(false);
    }
    public void ConsumableCancel()
    {       
        consumablesInfo.SetActive(false);
    }

    public void ConumableClicked()
    {
        consumablesInfo.SetActive(true);
    }

    public void ConsumablePurchase()
    {
        Debug.Log("Consumable has been purchased!");
    }
}
