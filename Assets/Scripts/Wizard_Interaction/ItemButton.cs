using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemButton : MonoBehaviour
{

    public GameObject sAndSInfo;
    public GameObject broadswordInfo;
    public GameObject daggerInfo;

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
        Debug.Log("Item purchased!");
    }

    public void BroadswordPurchased()
    {
        Debug.Log("Item purchase");
    }

    public void DaggerPurchased()
    {
        Debug.Log("Item purchase");
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
