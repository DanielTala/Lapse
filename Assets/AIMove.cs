using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMove : MonoBehaviour
{
    // Start is called before the first frame update

    public float speed;
    public float stoppingDistance;
    public float chaseRadius;
    public float retreatRadius;
    private Transform target;
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(transform.position, target.position) > stoppingDistance && Vector2.Distance(transform.position, target.position) <= chaseRadius)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
        else if(Vector2.Distance(transform.position, target.position) > stoppingDistance && Vector2.Distance(transform.position, target.position) <= chaseRadius && Vector2.Distance(transform.position, target.position) > retreatRadius)
        {
            transform.position = this.transform.position;
        }
        else if(Vector2.Distance(transform.position, target.position)<retreatRadius)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, -speed * Time.deltaTime);
        }
    }

}
