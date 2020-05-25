using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    // Start is called before the first frame update

    private bool portal;
    public bool stage1f;

    private void Update()
    {
        if (portal==true && Input.GetKeyDown(KeyCode.E))
        {
           
            SceneManager.LoadScene(1);
        }
        if (portal == true && Input.GetKeyDown(KeyCode.E) && stage1f==true)
        {

            SceneManager.LoadScene(3);
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            portal = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            portal = false;
        }
    }

    public void Stage1Finish()
    {
        stage1f = true;
    }
}
