using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stage2Objective : MonoBehaviour
{

    public float holder;
    public float holder2;
    public float saveTime;
    private bool flag = true;
    public HighButton hb;
    public Timer time;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && Input.GetKey(KeyCode.E))
        {
            hb = FindObjectOfType<HighButton>();
            time = FindObjectOfType<Timer>();
            saveTime = time.currentTime;

            if (PlayerPrefs.GetFloat("Highscore1d", 0f) <= saveTime && flag == true)
            {
                holder = 0;
                holder2 = 0;

                holder = PlayerPrefs.GetFloat("Highscore1d", 0);
                holder2 = PlayerPrefs.GetFloat("Highscore2d", 0);
                PlayerPrefs.SetFloat("Highscore2d", holder);
                PlayerPrefs.SetFloat("Highscore3d", holder2);
                flag = true;
                PlayerPrefs.SetFloat("Highscore1d", saveTime);

                flag = false;

                Debug.Log("Holder1" + holder + "Holder2d" + holder2);
            }
            else if (PlayerPrefs.GetFloat("Highscore2d", 0f) <= saveTime && flag == true)
            {
                Debug.Log("Pasok2");
                holder = PlayerPrefs.GetFloat("Highscore2d", 0);
                PlayerPrefs.SetFloat("Highscore3d", holder);
                PlayerPrefs.SetFloat("Highscore2d", saveTime);
                flag = false;

            }
            else if (PlayerPrefs.GetFloat("Highscore3d", 0f) <= saveTime && flag == true)
            {
                Debug.Log("Pasok3");
                PlayerPrefs.SetFloat("Highscore3d", saveTime);
                flag = false;
            }
            FindObjectOfType<Movement>().prespawn = true;
            FindObjectOfType<Loader>().loadlevel(5);


          
            
            this.gameObject.SetActive(false);
        }
    }
}
