using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHealth : MonoBehaviour
{
    public GameObject bar;
    public float health;
    private float maxhealth;
    private void Start()
    {
        maxhealth = health;
    }
    void Update()
    {
        bar.transform.localScale = new Vector3(1f*(health/maxhealth), 0.1f, 1f);
        if (health <= 0)
            Destroy(gameObject);
    }
}
