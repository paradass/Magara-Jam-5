using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolgeTakip : MonoBehaviour
{
    float mesafe,hiz;
    void Update()
    {
        mesafe = Vector3.Distance(transform.position, Karakter.Instance.transform.position);
        if(mesafe > 10)
        {
            hiz = 5;
        }
        else if(mesafe > 8)
        {
            hiz = 5;
        }
        else if (mesafe > 5)
        {
            hiz = 4f;
        }
        else if(mesafe > 3)
        {
            hiz = 3f;
        }
        else if(mesafe > 2 && mesafe <= 3)
        {
            hiz = 0;
        }
        else if(mesafe <= 2)
        {
            GameObject.Find("Gorev5").GetComponent<Gorev5>().golgelendi = true;
        }

        transform.position = Vector3.MoveTowards(transform.position, Karakter.Instance.transform.position, hiz * Time.deltaTime);

    }
}
