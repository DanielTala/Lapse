using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//To run this code, the enemy must have two sprites parented to the enemy.
//One must be higher and one must be lower in the Order in Layer
//To keep it simple, the sprite on top should be green and the one below should be red
//The public variable <bar> should be assigned to the Green Sprite. This can be done through drag and drop. Or it can be done by clicking the circle next to the empty field of <bar> in the inspector view.
//Enemies will only be affected by combat if they are assigned the tag <Enemy>.
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
        bar.transform.localScale = new Vector3(1f*(health/maxhealth), bar.transform.localScale.y, bar.transform.localScale.z);
        if (health <= 0)
            Destroy(gameObject);
    }
}
