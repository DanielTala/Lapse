using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{

    public  float currentTime = 0f;
    public  float startingTime = 60f;
    private int scene;
   
    [SerializeField] Text countdownText;
    // Start is called before the first frame update
    void Start()
    {
            currentTime = startingTime;
            countdownText.text = currentTime.ToString("0");

    }

    // Update is called once per frame
    void Update()
    {
       scene = SceneManager.GetActiveScene().buildIndex;
        GameObject[] objects = GameObject.FindGameObjectsWithTag("Enemy");
        countdownText.text = currentTime.ToString("0");

        if (scene == 1 && objects.Length!=0)
        {
            currentTime -= 1 * Time.deltaTime;
        }
        if (scene == 1 && objects.Length==0)
        {
            startingTime = currentTime;
        }
        if (scene == 3 && objects.Length != 0)
        {
            currentTime -= 1 * Time.deltaTime;
        }
    }


}
