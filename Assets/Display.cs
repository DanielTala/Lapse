using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Display : MonoBehaviour
{
    public float triggerDistance,fadeSpeed;
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
        if(Vector3.Distance(target.transform.position,initial.position) < triggerDistance)
        {
            GetComponent<SpriteRenderer>().color = Color.Lerp(GetComponent<SpriteRenderer>().color, Color.white,fadeSpeed);
            transform.position = Vector3.Lerp(transform.position, final.position, fadeSpeed);
            transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(4.5f, 4.5f, 4.5f), fadeSpeed);
        }
        else
        {
            GetComponent<SpriteRenderer>().color = Color.Lerp(GetComponent<SpriteRenderer>().color, Color.clear, fadeSpeed);
            transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(0, 0, 0), fadeSpeed);
            transform.position = Vector3.Lerp(transform.position, initial.position, fadeSpeed);
        }
    }
}
