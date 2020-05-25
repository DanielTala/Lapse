using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update

    public float moveSpeed;
    private bool teleport;
    public Rigidbody2D rb;
    public bool boost;
    public float boostCountdown;
    Vector2 movement;
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
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


        if (teleport && Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene(1);
        }
    }

    private void FixedUpdate()
    {
        if (boost == false)
            rb.MovePosition(rb.position + movement * moveSpeed);
        else
        {
            rb.MovePosition(rb.position + movement * moveSpeed * 1.3f);
            boostCountdown -= Time.deltaTime;
            if (boostCountdown <= 0)
                boost = false;
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
