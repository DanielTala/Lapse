using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FadingNotif : MonoBehaviour
{
    public void displayPurchase(string item)
    {
        GetComponent<TextMeshProUGUI>().color += new Color(0, 0, 0, 1);
        GetComponent<TextMeshProUGUI>().text = "You've bought " + item;
        transform.localScale = Vector3.one;
        gameObject.SetActive(true);
    }
    void Update()
    {
        if (GetComponent<TextMeshProUGUI>().color.a > 0)
        {
            GetComponent<TextMeshProUGUI>().color -= new Color(0, 0, 0, 1) * Time.deltaTime*2;
            transform.localScale += Vector3.one*Time.deltaTime;
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
