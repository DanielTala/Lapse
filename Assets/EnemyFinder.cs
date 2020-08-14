using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyFinder : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject win;
    private float timer;

    private Portal portal;
    void Start()
    {
        portal = GameObject.FindObjectOfType<Portal>();
    }

    // Update is called once per frame
    void Update()
    {

        GameObject[] objects = GameObject.FindGameObjectsWithTag("Enemy");


        Movement movement = FindObjectOfType<Movement>();


        
        if (objects.Length == 0)
        {
            timer += 1 * Time.deltaTime;
            movement.prespawn = true;
            if (timer >= 4f && win.activeInHierarchy == false)
            {
                win.SetActive(true);
                FindObjectOfType<Loader>().loadlevel(3);
                FindObjectOfType<DialogueManager>().shopButton.SetActive(false);
                FindObjectOfType<DialogueManager>().nextButton.SetActive(true);
                FindObjectOfType<DialogueManager>().exitButton.SetActive(false);

            }


            if (SceneManager.GetActiveScene().buildIndex == 2)
            {
                portal.Stage1Finish();
            }
        }

    }
}

