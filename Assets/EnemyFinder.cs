using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyFinder : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject win;
    private float timer;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        GameObject[] objects = GameObject.FindGameObjectsWithTag("Enemy");
        

        if(objects.Length==0)
        {
            win.SetActive(true);
            timer += 1 *Time.deltaTime;

            if (timer >=4f)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
            }
        }
    }
}
