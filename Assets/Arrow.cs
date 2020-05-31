using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 20f;
    public Rigidbody2D rb;
    public float damage =1;

    private Transform target;

    Vector2 moveDirection;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        moveDirection = (target.transform.position - transform.position).normalized * speed;
        rb.velocity = new Vector2(moveDirection.x, moveDirection.y);
    }

    bool blockCheck()
    {
        Combat targetCombatScript = target.GetComponent<Combat>();
        if (targetCombatScript.blocking == true)
        {
            if (targetCombatScript.attackDirection == Combat.directions.left)
            {
                if (target.transform.position.x > transform.position.x)
                    return true;
                else
                    return false;
            }
            else if (targetCombatScript.attackDirection == Combat.directions.right)
            {
                if (target.transform.position.x < transform.position.x)
                    return true;
                else
                    return false;
            }
            else
                return false;
        }
        else
            return false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player"&& blockCheck()==false)
        {
            collision.gameObject.GetComponent<Combat>().Health -= damage;
            Destroy(gameObject);
        }
    }



}
