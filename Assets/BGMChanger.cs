using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class BGMChanger : MonoBehaviour
{
    public AudioClip title, tower, stage1, stage2;
    public AudioSource audio,crossfade;
    public float speed,maxVolume;
    public bool fade;
    // Start is called before the first frame update
    void Start()
    {
        
    }

  public void ChangeBGM(int n)
    {
        crossfade.Stop();
        if (n == 0)
            crossfade.clip = title;
        if (n == 1)
            crossfade.clip = tower;
        if (n == 2)
            crossfade.clip = stage1;
        if (n == 3)
            crossfade.clip = stage2;
        crossfade.volume = 0;
        fade = true;

    }
    void Update()
    {
        if(fade && !crossfade.isPlaying)
            crossfade.Play();
        else if (fade)
        {
            audio.volume -= Time.deltaTime * speed;
            crossfade.volume += Time.deltaTime * speed;
            if(crossfade.volume>=maxVolume)
            {
                audio.Stop();
                audio.clip = crossfade.clip;
                audio.time = crossfade.time;
                audio.Play();
                audio.volume = maxVolume;
                crossfade.Stop();
                crossfade.volume = 0;
                fade = false;
            }
        }
    }
}
