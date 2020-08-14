using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyFinder : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject win;
    private float timer;
    public HighButton hb;
    public Timer time;
    private Portal portal;

    public float holder;
    public float holder2;
    public float saveTime;
    private bool flag = true;
    void Start()
    {
        portal = GameObject.FindObjectOfType<Portal>();
    }

    // Update is called once per frame
    void Update()
    {

        GameObject[] objects = GameObject.FindGameObjectsWithTag("Enemy");
        time = FindObjectOfType<Timer>();

        Movement movement = FindObjectOfType<Movement>();

        if (Input.GetKeyDown(KeyCode.LeftBracket) && Input.GetKeyDown(KeyCode.RightBracket))
        {
            time.currentTime += 20f;
        }
        
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
            hb = FindObjectOfType < HighButton >();
            
            saveTime = time.currentTime;

            if (PlayerPrefs.GetFloat("Highscore1", 0f) <= saveTime && flag== true)
            {
                holder = 0;
                holder2 = 0;
     
                    holder = PlayerPrefs.GetFloat("Highscore1", 0);
                    holder2 = PlayerPrefs.GetFloat("Highscore2", 0);
                    PlayerPrefs.SetFloat("Highscore2", holder);
                    PlayerPrefs.SetFloat("Highscore3", holder2);
                    flag = true;
                    PlayerPrefs.SetFloat("Highscore1", saveTime);

                flag = false;

                Debug.Log("Holder1" + holder +"Holder2" + holder2);
            }
            else if(PlayerPrefs.GetFloat("Highscore2", 0f) <= saveTime && flag == true)
            {
                Debug.Log("Pasok2");
                holder = PlayerPrefs.GetFloat("Highscore2", 0);
                PlayerPrefs.SetFloat("Highscore3", holder);
                PlayerPrefs.SetFloat("Highscore2", saveTime);
                flag = false;

            }
            else if (PlayerPrefs.GetFloat("Highscore3", 0f) <= saveTime && flag == true)
            {
                Debug.Log("Pasok3");
                PlayerPrefs.SetFloat("Highscore3", saveTime);
                flag = false;
            }


        }

    }
}

