using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiate : MonoBehaviour
{
    // Start is called before the first frame update
    // Start is called before the first frame update
    public Transform firePoint;
    public GameObject bulletPrefab;
    private Transform target;
    public float AttackRadius;
    private float timeBtwShots;
    public float startTimeBtwShots;

    private void Start()
    {

    }

    void Update()
    {


        if (timeBtwShots <= 0)
        {

            if (Input.GetKeyDown(KeyCode.E))
            {

                Shoot();


            }
        }

    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, transform.rotation);
    }
}
