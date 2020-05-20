using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
        if (GameObject.Find(gameObject.name) && GameObject.Find(gameObject.name) != this.gameObject)
            Destroy(GameObject.Find(gameObject.name));
    }
}
