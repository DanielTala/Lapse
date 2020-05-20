using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class layerChnge : MonoBehaviour
{
    Transform target;
    public float offset;
    // Start is called before the first frame update
    void Start()
    {

        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (target.position.y > transform.position.y+offset)
        {
            GetComponent<SpriteRenderer>().color = new Color(0.5f, 0.5f, 0.5f, 0.5f);
            GetComponent<SpriteRenderer>().sortingOrder = 4;

        }
        else
        {
            GetComponent<SpriteRenderer>().color = Color.white;
            GetComponent<SpriteRenderer>().sortingOrder = 2;
        }
    }
}
