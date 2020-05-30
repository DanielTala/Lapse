using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Loader : MonoBehaviour
{

    public Dialogue tips;
    public CanvasGroup loadingScreen;
    public Slider bar;
    public TextMeshProUGUI tipDisplay;
    public Animator lod;
    public void loadlevel(int i)
    {
        int random = Random.Range(0, tips.sentences.Length);
        tipDisplay.text = tips.sentences[random];
        loadingScreen.blocksRaycasts = true;
        loadingScreen.alpha = 1;
        StartCoroutine(loadasync(i));
    }
    IEnumerator loadasync(int index)
    {
        AsyncOperation oper = SceneManager.LoadSceneAsync(index);
        while (!oper.isDone)
        {
            if(!FindObjectOfType<BGMChanger>().crossfade.isPlaying)
            {
                if (index == 1 || index == 3)
                    FindObjectOfType<BGMChanger>().ChangeBGM(1);
                if (index == 2)
                    FindObjectOfType<BGMChanger>().ChangeBGM(2);
                if (index == 4)
                    FindObjectOfType<BGMChanger>().ChangeBGM(3);

            }
            float pr = Mathf.Clamp01(oper.progress / 0.9f);
            bar.value = pr;
            tipDisplay.color = new Color(1, 1, 1, Mathf.PingPong(1.5f, 1f) + 0.5f);
            Debug.Log(pr);
            Debug.Log(tipDisplay.text);
            yield return null;
        }
        yield return new WaitForSeconds(2);
        loadingScreen.blocksRaycasts = false;
        loadingScreen.alpha = 0;
        bar.value = 0;
    }
}
