using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stage2Objective : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && Input.GetKey(KeyCode.E))
        {
            Debug.Log("S2");
            FindObjectOfType<Movement>().prespawn = true;
            FindObjectOfType<Loader>().loadlevel(5);
            this.gameObject.SetActive(false);
        }
    }
}
