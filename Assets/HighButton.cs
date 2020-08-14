using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HighButton : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject highscore;
    public TextMeshProUGUI h1;
    public TextMeshProUGUI h2;
    public TextMeshProUGUI h3;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void hbutton()
    {
        highscore.SetActive(true);
        h1.text = PlayerPrefs.GetFloat("Highscore1", 0f).ToString() + "s";
        h2.text = PlayerPrefs.GetFloat("Highscore2", 0f).ToString() + "s";
        h3.text = PlayerPrefs.GetFloat("Highscore3", 0f).ToString() + "s";

    }

    public void xbutton()
    {
        highscore.SetActive(false);
    }

}
