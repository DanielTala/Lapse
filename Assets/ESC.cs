﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ESC : MonoBehaviour
{
    public GameObject screen;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            screen.SetActive(true);
            FindObjectOfType<Movement>().enabled = false;
            FindObjectOfType<Combat>().enabled = false;
            FindObjectOfType<Timer>().enabled = false;
            foreach (Melee abc in FindObjectsOfType<Melee>())
            {
                abc.enabled = false;
            }
            foreach (RangeAttack abc in FindObjectsOfType<RangeAttack>())
            {
                abc.enabled = false;
            }
        }
    }
    public void resume()
    {
        screen.SetActive(false);
        FindObjectOfType<Movement>().enabled = true;
        FindObjectOfType<Combat>().enabled = true;
        FindObjectOfType<Timer>().enabled = true;
        foreach (Melee abc in FindObjectsOfType<Melee>())
        {
            abc.enabled = true;
        }
        foreach (RangeAttack abc in FindObjectsOfType<RangeAttack>())
        {
            abc.enabled = true;
        }
    }
    public void restart()
    {

        Destroy(FindObjectOfType<Combat>().gameObject);
        FindObjectOfType<Loader>().loadlevel(1);
    }
    public void exit()
    {
        Application.Quit();
    }
}
