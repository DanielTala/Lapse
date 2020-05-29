using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepUpright1 : MonoBehaviour
{
    public bool on;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(on)
        {
            transform.rotation = Quaternion.Euler(Vector3.zero);
        }
    }
}
