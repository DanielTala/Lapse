using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_Attack : MonoBehaviour
{

    public GameObject up;

    public GameObject left;

    public GameObject low;

    public GameObject right;
    private Transform pos;
    public Rigidbody2D rb;
    Vector2 movement;
    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (movement.x == 1 && movement.y == 0)
        {
            Debug.Log("Right");
            rb.MovePosition(right.transform.position);
        }

        else if (movement.x == 0 && movement.y == 1)
        {
            Debug.Log("Up");
            rb.MovePosition(up.transform.position);
        }
        else if (movement.x == -1 && movement.y == 0)
        {
            Debug.Log("Left");
            rb.MovePosition(left.transform.position);
        }

        else if (movement.x == 0 && movement.y == -1)
        {
            Debug.Log("Low");
            rb.MovePosition(low.transform.position);
        }
    }


}
