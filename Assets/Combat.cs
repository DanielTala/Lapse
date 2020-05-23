using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//When running the game, you can freely change stats for each variable but for them to remain you must input the same values inside <WeaponChange()>
//<WeaponChange()> only runs when the selected weapon is not the same as the current weapon, which is why I made the player start with None.
public class Combat : MonoBehaviour
{
    public enum weapons { None,Sword, Dagger, Broadsword };
    public enum directions { up, down, left, right };
    [Range(1f, 20f)]
    public float damage;
    [Range(1f, 10f)]
    public float range;
    [Range(1f, 10f)]
    public float attacksPerSecond;
    [Range(0f, 90f)]
    public float attackSpread;
    private float attackCooldown;
    public weapons selectedWeapon;
    private weapons currentWeapon;
    public directions attackDirection;

    public GameObject bar;
    public Vector3 initial;
    [Range(0f, 100f)]
    public float Health;
    private float maxhealth;
    void WeaponChange()
    {
        if (currentWeapon != selectedWeapon)
        {
            if (selectedWeapon == weapons.Sword)
            {
                damage = 8f;
                range = 4f;
                attacksPerSecond = 1.5f;
                attackSpread = 45f;
                currentWeapon = selectedWeapon;
            }
            if (selectedWeapon == weapons.Dagger)
            {
                damage = 5f;
                range = 3f;
                attacksPerSecond = 2f;
                attackSpread = 30f;
                currentWeapon = selectedWeapon;
            }
            if (selectedWeapon == weapons.Broadsword)
            {
                damage = 14f;
                range = 6f;
                attacksPerSecond = 1f;
                attackSpread = 60f;
                currentWeapon = selectedWeapon;
            }
        }
    }
    void Start()
    {
        currentWeapon = weapons.None;
        WeaponChange();
        attackCooldown = 1f / attacksPerSecond;
        maxhealth = Health;
        initial = bar.transform.localScale;
    }
    public void Attack()
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
        Vector3 leftRayRotation = Quaternion.AngleAxis(-attackSpread, transform.forward) * dir;
        Vector3 leftMidRayRotation = Quaternion.AngleAxis(-attackSpread/2, transform.forward) * dir;
        Vector3 rightRayRotation = Quaternion.AngleAxis(attackSpread, transform.forward) *dir;
        Vector3 rightMidRayRotation = Quaternion.AngleAxis(attackSpread/2, transform.forward) *dir;
        Ray2D ray = new Ray2D(transform.position, dir);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, range);
        Debug.DrawRay(transform.position, dir, Color.red, 0.1f);
        if (hit.collider != null && hit.collider.gameObject.tag == "Enemy")
        {
            Debug.Log("Target Position: " + hit.transform.position);
            hit.collider.gameObject.GetComponent<enemyHealth>().health -= damage;
        }
        ray = new Ray2D(transform.position, leftRayRotation);
        hit = Physics2D.Raycast(ray.origin, ray.direction, range);
        Debug.DrawRay(transform.position, leftRayRotation, Color.red, 0.1f);
        if (hit.collider != null && hit.collider.gameObject.tag == "Enemy")
        {
            Debug.Log("Target Position: " + hit.transform.position);
            hit.collider.gameObject.GetComponent<enemyHealth>().health -= damage;
        }
        ray = new Ray2D(transform.position, leftMidRayRotation);
        hit = Physics2D.Raycast(ray.origin, ray.direction, range);
        Debug.DrawRay(transform.position, leftMidRayRotation, Color.red, 0.1f);
        if (hit.collider != null && hit.collider.gameObject.tag == "Enemy")
        {
            Debug.Log("Target Position: " + hit.transform.position);
            hit.collider.gameObject.GetComponent<enemyHealth>().health -= damage;
        }
        ray = new Ray2D(transform.position, rightRayRotation);
        hit = Physics2D.Raycast(ray.origin, ray.direction, range);
        Debug.DrawRay(transform.position, rightRayRotation, Color.red, 0.1f);
        if (hit.collider != null && hit.collider.gameObject.tag == "Enemy")
        {
            Debug.Log("Target Position: " + hit.transform.position);
            hit.collider.gameObject.GetComponent<enemyHealth>().health -= damage;
        }
        ray = new Ray2D(transform.position, rightMidRayRotation);
        hit = Physics2D.Raycast(ray.origin, ray.direction, range);
        Debug.DrawRay(transform.position, rightMidRayRotation, Color.red, 0.1f);
        if (hit.collider != null && hit.collider.gameObject.tag == "Enemy")
        {
            Debug.Log("Target Position: " + hit.transform.position);
            hit.collider.gameObject.GetComponent<enemyHealth>().health -= damage;
        }




    }
    void Update()
    {
        attackCooldown -= Time.deltaTime;
        WeaponChange();
        if (Input.GetKey(KeyCode.Space) && attackCooldown <= 0&& selectedWeapon != weapons.None)
        {
            GetComponent<Animator>().Play("Player_Attacking", 0, 0f);
            attackCooldown = 1f / attacksPerSecond;
        }
        bar.transform.localScale = new Vector3(initial.x * (Health / maxhealth), initial.y, initial.z);
        if (Health <= 0)
            Destroy(gameObject);


    }
}