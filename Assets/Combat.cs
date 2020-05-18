using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour
{
    public enum weapons { Sword, Dagger, Broadsword };    
    public enum directions { up, down, left, right };


    [Range(1f, 20f)]
    public float damage;
    [Range(1f, 10f)]
    public float range;
    [Range(1f, 10f)]
    public float attacksPerSecond;
    private  float attackCooldown;

    public weapons selectedWeapon;
    private weapons currentWeapon;
    public directions attackDirection;
    void WeaponChange()
    {
        if (currentWeapon != selectedWeapon)
        {
            if (selectedWeapon == weapons.Sword)
            {
                damage = 8f;
                range = 4f;
                attacksPerSecond =2f;
                currentWeapon = selectedWeapon;
            }
            if (selectedWeapon == weapons.Dagger)
            {
                damage = 5f;
                range = 3f;
                attacksPerSecond = 4f;
                currentWeapon = selectedWeapon;
            }
            if (selectedWeapon == weapons.Broadsword)
            {
                damage = 14f;
                range = 6f;
                attacksPerSecond = 1f;
                currentWeapon = selectedWeapon;
            }
        }
    }
     void Start()
    {

        WeaponChange();
        attackCooldown = 1f / attacksPerSecond;
    }
    void Update()
    {
        attackCooldown -= Time.deltaTime;
        WeaponChange();



        if (Input.GetKey(KeyCode.Space) && attackCooldown <= 0)
        {
            Vector2 dir = Vector2.zero; ;
            if (attackDirection == directions.up)
                dir = transform.up * range;
            if (attackDirection == directions.down)
                dir = -transform.up * range;
            if (attackDirection == directions.left)
                dir = -transform.right * range;
            if (attackDirection == directions.right)
                dir = transform.right * range;

            Ray2D ray = new Ray2D(transform.position, dir);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, range);
            Debug.DrawRay(transform.position, dir, Color.red, 0.1f);
            if (hit.collider != null && hit.collider.gameObject.name == "Melee")
            {
                Debug.Log("Target Position: " + hit.transform.position);
                hit.collider.gameObject.GetComponent<enemyHealth>().health -= damage;
            }
            else
            {
                ray = new Ray2D(transform.position, dir + Vector2.up * 2);
                hit = Physics2D.Raycast(ray.origin, ray.direction, range);
                Debug.DrawRay(transform.position, dir + Vector2.up * 2, Color.red, 0.1f);
                if (hit.collider != null && hit.collider.gameObject.name == "Melee")
                {
                    Debug.Log("Target Position: " + hit.transform.position);
                    hit.collider.gameObject.GetComponent<enemyHealth>().health -= damage;
                }
                else
                {
                    ray = new Ray2D(transform.position, dir + Vector2.down * 2);
                    hit = Physics2D.Raycast(ray.origin, ray.direction, range);
                    Debug.DrawRay(transform.position, dir + Vector2.down * 2, Color.red, 0.1f);
                    if (hit.collider != null && hit.collider.gameObject.name == "Melee")
                    {
                        Debug.Log("Target Position: " + hit.transform.position);
                        hit.collider.gameObject.GetComponent<enemyHealth>().health -= damage;
                    }
                }
            }



            GetComponent<Animator>().Play("Player_Attacking", 0, 0f);
            attackCooldown = 1f / attacksPerSecond;
        }
    }
}
