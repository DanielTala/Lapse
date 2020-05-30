using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Since not all trees are the same size, just edit the offset variable until you get the right behavior
public class layerChnge : MonoBehaviour
{
    Transform target;
    public float offset;
     int order;
    // Start is called before the first frame update
    void Start()
    {
        order = GetComponent<SpriteRenderer>().sortingOrder;
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (target.position.y > transform.position.y+offset)
        {
            GetComponent<SpriteRenderer>().color = new Color(0.5f, 0.5f, 0.5f, 0.5f);

            GetComponent<SpriteRenderer>().sortingOrder = order+20;

        }
        else
        {
            GetComponent<SpriteRenderer>().color = Color.white;
            GetComponent<SpriteRenderer>().sortingOrder = order;
        }
    }
}
