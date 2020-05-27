using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemButton : MonoBehaviour
{

    public GameObject sAndSInfo;
    public GameObject broadswordInfo;
    public GameObject daggerInfo;

    public void Update()
    {
        Timer timer = FindObjectOfType<Timer>();
    }

    public void SAndSClicked()
    {
        sAndSInfo.SetActive(true);
    }

    public void BroadswordClicked()
    {
        broadswordInfo.SetActive(true);
    }

    public void DaggerClicked()
    {
        daggerInfo.SetActive(true);
    }

    public void SAndSPurchased()
    {
        Combat combat = FindObjectOfType<Combat>();
        Timer timer = FindObjectOfType<Timer>();
        Debug.Log("Item purchase");
        if (timer.currentTime >= 25f && combat.weaponNumber != 2)
        {
            timer.currentTime -= 25f;
            combat.WeaponSelect(2);
        }
    }

    public void BroadswordPurchased()
    {
        Combat combat = FindObjectOfType<Combat>();
        Timer timer = FindObjectOfType<Timer>();
        Debug.Log("Item purchase");
        if (timer.currentTime >= 30f && combat.weaponNumber != 4)
        {
            timer.currentTime -= 30f;
            combat.WeaponSelect(4);
        }
    }

    public void DaggerPurchased()
    {
        Combat combat = FindObjectOfType<Combat>();
        Timer timer = FindObjectOfType<Timer>();
        Debug.Log("Item purchase");
        if (timer.currentTime >= 25f && combat.weaponNumber != 3)
        {
            timer.currentTime -= 25f;
            combat.WeaponSelect(3);
        }
    }

    public void SAndSCanceled()
    {
        sAndSInfo.SetActive(false);
    }

    public void BroadswordCanceled()
    {
        broadswordInfo.SetActive(false);
    }

    public void DaggerCanceled()
    {
        daggerInfo.SetActive(false);
    }
    
    
}
