﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Inventory : MonoBehaviour
{
    public int HPCount, SPCount;
    public Button HPDisp, SPDisp;
    public TextMeshProUGUI HPText, SPText;

    public void addHPPotion()
    {
        if (HPCount <5)
        {
            HPCount++;
            HPDisp.gameObject.SetActive(true);
            FindObjectOfType<Timer>().currentTime -= 2;
        }
        HPText.text = HPCount.ToString();
    }
    public void consumeHPPotion()
    {
        if(HPCount > 0)
        {
            HPCount--;
            if (HPCount == 0)
                HPDisp.gameObject.SetActive(false);
            FindObjectOfType<Combat>().Health += 20;
            if (FindObjectOfType<Combat>().Health > FindObjectOfType<Combat>().maxhealth)
                FindObjectOfType<Combat>().Health = FindObjectOfType<Combat>().maxhealth;
        }
        HPText.text = HPCount.ToString();
    }
    public void addSPPotion()
    {
        if (SPCount <2)
        {
            SPCount++;
            SPDisp.gameObject.SetActive(true);
            FindObjectOfType<Timer>().currentTime -= 5;
        }
        SPText.text = SPCount.ToString();
    }
    public void consumeSPPotion()
    {
        if (SPCount > 0 && FindObjectOfType<Movement>().boost == false)
        {
            SPCount--;
            if (SPCount == 0)
                SPDisp.gameObject.SetActive(false);

            FindObjectOfType<Movement>().boost = true;
            FindObjectOfType<Movement>().boostCountdown = 10f;

        }
        SPText.text = SPCount.ToString();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            consumeHPPotion();
        }
        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            consumeSPPotion();
        }
       // if(Input.GetKeyDown(KeyCode.Alpha2))
    }
}
