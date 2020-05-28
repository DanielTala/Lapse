using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update

    public float moveSpeed;
    public bool prespawn;
    private bool teleport;
    public Rigidbody2D rb;
    public bool boost,lockMovement;
    public float boostCountdown;
    Vector2 movement;

    Vector2 moveDirection;
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (!lockMovement)
        {
            movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        
            if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
                GetComponent<Animator>().SetInteger("state", 1);
            else
                GetComponent<Animator>().SetInteger("state", 0);
            if (movement.x > 0)
            {
                GetComponent<Combat>().attackDirection = Combat.directions.right;
                GetComponent<SpriteRenderer>().flipX = true;
            }
            else if (movement.x < 0)
            {
                GetComponent<Combat>().attackDirection = Combat.directions.left;
                GetComponent<SpriteRenderer>().flipX = false;
            }
        }


        if (teleport && Input.GetKeyDown(KeyCode.E))
        {
            FindObjectOfType<Loader>().loadlevel(1);
        }


    }
    private void FixedUpdate()
    {
        if (boost == false)
            rb.MovePosition(rb.position + movement * moveSpeed*Time.deltaTime);
        else
        {
            rb.MovePosition(rb.position + movement * moveSpeed * Time.deltaTime * 1.5f);
            boostCountdown -= Time.deltaTime;
            if (boostCountdown <= 0)
                boost = false;
        }
        GameObject spawn = GameObject.FindGameObjectWithTag("Spawn");
        if (prespawn == true)
        {
            rb.MovePosition(spawn.transform.position);
            prespawn = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ChangeScene"))
        {
            teleport = true;
        }
        
        if (collision.CompareTag("Barriers"))
        {
            teleport = false;
        }

    }
}
