using System.Collections;
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
            foreach(Melee abc in FindObjectsOfType<Melee>())
            {
                abc.enabled = false;
            }
        }
    }
    public void resume()
    {
        screen.SetActive(false);
        FindObjectOfType<Movement>().enabled = true;
        foreach (Melee abc in FindObjectsOfType<Melee>())
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
