using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee1 : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 20f;
    public Rigidbody2D rb;

    private Transform target;

    Vector2 moveDirection;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("P_Attack").GetComponent<Transform>();
        moveDirection = (target.transform.position - transform.position).normalized * speed;
        rb.velocity = new Vector2(moveDirection.x, moveDirection.y);
        DestroyObject(gameObject, 0.5f);
    }

    void Update()
    {

    }
}
