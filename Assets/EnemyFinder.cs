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


        Debug.Log(SceneManager.GetActiveScene().buildIndex);
        if(objects.Length==0)
        {
            win.SetActive(true);
            timer += 1 *Time.deltaTime;
            movement.prespawn = true;
            if (timer >=4f)
            {
                SceneManager.LoadScene(2);
            }
            
            if (SceneManager.GetActiveScene().buildIndex==1)
            {
                portal.Stage1Finish();
            }

          
        }
    }
}
