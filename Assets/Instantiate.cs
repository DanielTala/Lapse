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
    private float variable;
    private float handle;
    private float handle1;
    private bool flag;
    private void Start()
    {

    }

    void Update()
    {

        handle1 = Input.GetAxisRaw("Horizontal");
        handle = Input.GetAxisRaw("Vertical");

        if (handle1 == 1 || handle == -1)
        {
            flag = true;
        }
        else
        {
            flag = false;
        }

        if (flag == false)
        {
            variable = 90f;
        }
        else
        {
            variable = 0f;
        }

            if (Input.GetKeyDown(KeyCode.E))
            {
                Shoot();
            }

    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, Quaternion.Euler(0f,0f, variable));
    }
}
