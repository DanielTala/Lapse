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
    // Update is called once per frame
    void Update()
    {
        damageCooldown -= Time.deltaTime;
        if (Vector2.Distance(transform.position, target.position) > stoppingDistance && Vector2.Distance(transform.position, target.position) <= chaseRadius)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
        if (Vector2.Distance(transform.position, target.position) <= stoppingDistance &&damageCooldown<=0&& blockCheck() == false)
        {
            Debug.DrawLine(transform.position, target.transform.position, Color.red, 0.2f);
            target.gameObject.GetComponent<Combat>().Health -= damage;
            damageCooldown = damageInterval;
        }
    }
}
