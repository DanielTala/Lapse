using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeAttack : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform firePoint;
    public GameObject bulletPrefab;
    private Transform target;
    public float AttackRadius;
    private float timeBtwShots;
    public float startTimeBtwShots;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {
        if (Vector2.Distance(transform.position, target.position) < AttackRadius)
        {
            if (target.position.x > transform.position.x)
                GetComponent<SpriteRenderer>().flipX = true;
            else if (target.position.x < transform.position.x)
                GetComponent<SpriteRenderer>().flipX = false;

            if (timeBtwShots <= 0)
            {

                if (Vector2.Distance(transform.position, target.position) < AttackRadius)
                {
                    timeBtwShots = startTimeBtwShots;
                    GetComponent<Animator>().Play("Slime_Attacking", 0, 0f);

                }
            }
        }
        timeBtwShots -= Time.deltaTime;
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, transform.rotation);
    }
}
