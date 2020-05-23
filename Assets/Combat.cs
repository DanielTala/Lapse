using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//When running the game, you can freely change stats for each variable but for them to remain you must input the same values inside <WeaponChange()>
//<WeaponChange()> only runs when the selected weapon is not the same as the current weapon, which is why I made the player start with None.
public class Combat : MonoBehaviour
{
    public enum weapons { None, Sword,SwordShield, Dagger, Broadsword };
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
    public Animator animator;
    public AnimatorOverrideController NoWeapon, Sword, SwordShield,Dagger,BroadSword;
    public Motion[] motions;
    public bool blocking;


    public GameObject bar;
    public Vector3 initial;
    [Range(0f, 100f)]
    public float Health;
    public float maxhealth;

    //protected AnimatorOverrideController AOC;

    public void WeaponSelect(int index)
    {
        Timer timer = FindObjectOfType<Timer>();
        if (index == 0)
            selectedWeapon = weapons.None;
        if (index == 1)
        {
            selectedWeapon = weapons.Sword;
        }
        if (index == 2)
        {
            selectedWeapon = weapons.SwordShield;
            timer.currentTime -= 25f;
        }
        if (index == 3)
        {
            selectedWeapon = weapons.Dagger;
            timer.currentTime -= 25f;
        }
        if (index == 4)
        {
            selectedWeapon = weapons.Broadsword;
            timer.currentTime -=  25f;
        }
    }

    void WeaponChange()
    {
        if (currentWeapon != selectedWeapon)
        {
            if (selectedWeapon == weapons.None)
            {
                damage = 1f;
                range = 1f;
                attacksPerSecond = 1f;
                attackSpread = 0f;
                currentWeapon = selectedWeapon;
                animator.runtimeAnimatorController = NoWeapon;
            }
            if (selectedWeapon == weapons.Sword)
            {
                damage = 8f;
                range = 4f;
                attacksPerSecond = 1.5f;
                attackSpread = 45f;
                currentWeapon = selectedWeapon;
                animator.runtimeAnimatorController = Sword;
            }
            if (selectedWeapon == weapons.SwordShield)
            {
                damage = 8f;
                range = 4f;
                attacksPerSecond = 1.5f;
                attackSpread = 45f;
                currentWeapon = selectedWeapon;
                animator.runtimeAnimatorController = SwordShield;
            }
            if (selectedWeapon == weapons.Dagger)
            {
                damage = 5f;
                range = 3f;
                attacksPerSecond = 2f;
                attackSpread = 30f;
                currentWeapon = selectedWeapon;
                animator.runtimeAnimatorController = SwordShield;
            }
            if (selectedWeapon == weapons.Broadsword)
            {
                damage = 14f;
                range = 6f;
                attacksPerSecond = 1f;
                attackSpread = 60f;
                currentWeapon = selectedWeapon;
                animator.runtimeAnimatorController = SwordShield;
            }
        }
    }
    void Start()
    {
        blocking = false;
        currentWeapon = weapons.None;
        WeaponChange();
        attackCooldown = 1f / attacksPerSecond;
        maxhealth = Health;
        initial = bar.transform.localScale;
        animator = GetComponent<Animator>();
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
        Vector3 leftMidRayRotation = Quaternion.AngleAxis(-attackSpread / 2, transform.forward) * dir;
        Vector3 rightRayRotation = Quaternion.AngleAxis(attackSpread, transform.forward) * dir;
        Vector3 rightMidRayRotation = Quaternion.AngleAxis(attackSpread / 2, transform.forward) * dir;
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
        if (Input.GetKey(KeyCode.Space) && attackCooldown <= 0 && selectedWeapon != weapons.None)
        {
            GetComponent<Animator>().Play("Player_Attacking", 0, 0f);
            attackCooldown = 1f / attacksPerSecond;
        }
        if(Input.GetKeyDown(KeyCode.LeftControl) && selectedWeapon == weapons.SwordShield)
            GetComponent<Animator>().Play("Player_BlockingStart", 0, 0f);
        if (Input.GetKey(KeyCode.LeftControl) &&selectedWeapon == weapons.SwordShield)
        {
            Debug.Log("Blocking");
            GetComponent<Animator>().SetInteger("state", 4);
            blocking = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            GetComponent<Animator>().Play("Player_BlockingEnd", 0, 0f);
            blocking = false;
        }
        bar.transform.localScale = new Vector3(initial.x * (Health / maxhealth), initial.y, initial.z);
        if (Health <= 0)
            Destroy(gameObject);


    }
}