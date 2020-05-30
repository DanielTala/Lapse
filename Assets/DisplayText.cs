using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayText : MonoBehaviour
{
    public float triggerDistance, fadeSpeed;
    public Transform initial, final;
    GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.localScale.x < 0.95f)
        {
            transform.position = Vector3.Lerp(transform.position, final.position, fadeSpeed);
            transform.localScale = Vector3.Lerp(transform.localScale, Vector3.one, fadeSpeed);
        }
        else
        {
            transform.position = new Vector3(final.position.x, (final.position.y + Mathf.PingPong(Time.time, 1)), final.position.z);
        }
    }
}