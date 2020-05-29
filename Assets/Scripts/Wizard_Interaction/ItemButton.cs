using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemButton : MonoBehaviour
{

    public GameObject sAndSInfo;
    public GameObject broadswordInfo;
    public GameObject HPInfo;
    public GameObject SPInfo;
    public FadingNotif purchaseDisp;
    public Inventory inv;

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


    public void HPClicked()
    {
        HPInfo.SetActive(true);
    }

    public void SPClicked()
    {
        SPInfo.SetActive(true);
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
            purchaseDisp.displayPurchase("a Sword and Shield");
        }
        SAndSCanceled();
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
            purchaseDisp.displayPurchase("a Broadsword");
        }
        BroadswordCanceled();
    }

    public void HPPurchased()
    {
        Timer timer = FindObjectOfType<Timer>();
        Debug.Log("Item purchase");
        if (inv.HPCount < 5)
        {
            inv.HPCount++;
            inv.HPDisp.gameObject.SetActive(true);
            timer.currentTime -= 2;
            purchaseDisp.displayPurchase("a Health Potion");
        }
        inv.HPText.text = inv.HPCount.ToString();
    }
    public void SPPurchased()
    {
        Timer timer = FindObjectOfType<Timer>();
        Debug.Log("Item purchase");
        if (inv.SPCount < 2)
        {
            inv.SPCount++;
            inv.SPDisp.gameObject.SetActive(true);
            timer.currentTime -= 5;
            purchaseDisp.displayPurchase("a Speed Potion");
        }
        inv.SPText.text = inv.SPCount.ToString();
    }

    public void SAndSCanceled()
    {
        sAndSInfo.SetActive(false);
    }

    public void BroadswordCanceled()
    {
        broadswordInfo.SetActive(false);
    }

    public void HPCanceled()
    {
        HPInfo.SetActive(false);
    }

    public void SPCanceled()
    {
        SPInfo.SetActive(false);
    }


}
