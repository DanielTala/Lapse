using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee : MonoBehaviour
{
    // Start is called before the first frame update

    public float speed;
    public float stoppingDistance;
    public float chaseRadius;
    public float retreatRadius;
    public float damage, damageInterval;
    private float damageCooldown;
    private Transform target;
    void Start()
    {
        damageCooldown = damageInterval;
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    // Update is called once per frame
    void Update()
    {
        damageCooldown -= Time.deltaTime;
        if (Vector2.Distance(transform.position, target.position) > stoppingDistance && Vector2.Distance(transform.position, target.position) <= chaseRadius)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
        if (Vector2.Distance(transform.position, target.position) <= stoppingDistance &&damageCooldown<=0)
        {
            target.gameObject.GetComponent<Combat>().Health -= damage;
            damageCooldown = damageInterval;
        }
    }
}
