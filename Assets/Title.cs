using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Title : MonoBehaviour
{
    public Image titleImage, controlImage;
    public float speed;
    public bool fade;
    // Start is called before the first frame update
    void Start()
    {
        fade = false;
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.anyKeyDown || Input.GetMouseButtonDown(0)) && !fade)
            fade = true;
       
        if (!titleImage.gameObject.activeInHierarchy && fade)
        {
            controlImage.color -= new Color(0, 0, 0, 1) * speed * Time.deltaTime;
            if (controlImage.color.a <= 0.2f)
            {
                FindObjectOfType<Loader>().loadlevel(1);
                controlImage.color = new Color(1, 1, 1, 0);
                controlImage.gameObject.SetActive(false);
                fade = false;
            }
        }
        else if (fade)
        {
            titleImage.color -= new Color(0, 0, 0, 1) * speed * Time.deltaTime;
            controlImage.color += new Color(0, 0, 0, 1) * speed * Time.deltaTime;
            if (titleImage.color.a <= 0)
            {
                titleImage.color = new Color(1, 1, 1, 0);
                controlImage.color = new Color(1, 1, 1, 1);
                titleImage.gameObject.SetActive(false);
                fade = false;
            }
        }

        if(Input.GetKeyDown(KeyCode.F1))
        {
            PlayerPrefs.DeleteKey("Highscore1");
            PlayerPrefs.DeleteKey("Highscore2");
            PlayerPrefs.DeleteKey("Highscore3");
        }
    }
}
