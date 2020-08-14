using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class HighButton : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject highscore1;
    public GameObject highscore2;
    public TextMeshProUGUI h1;
    public TextMeshProUGUI h2;
    public TextMeshProUGUI h3;
    public TextMeshProUGUI h1d;
    public TextMeshProUGUI h2d;
    public TextMeshProUGUI h3d;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void hbutton()
    {
        if(SceneManager.GetActiveScene().buildIndex == 3)
        highscore1.SetActive(true);
        if (SceneManager.GetActiveScene().buildIndex == 5)
        highscore2.SetActive(true);

        h1.text = PlayerPrefs.GetFloat("Highscore1", 0f).ToString() + " s";
        h2.text = PlayerPrefs.GetFloat("Highscore2", 0f).ToString() + " s";
        h3.text = PlayerPrefs.GetFloat("Highscore3", 0f).ToString() + " s";

        h1d.text = PlayerPrefs.GetFloat("Highscore1d", 0f).ToString() + " s";
        h2d.text = PlayerPrefs.GetFloat("Highscore2d", 0f).ToString() + " s";
        h3d.text = PlayerPrefs.GetFloat("Highscore3d", 0f).ToString() + " s";
    }

    public void xbutton()
    {
        highscore1.SetActive(false);
        highscore2.SetActive(false);
    }

}
