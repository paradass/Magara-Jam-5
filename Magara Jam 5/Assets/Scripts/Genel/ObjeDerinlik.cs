using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjeDerinlik : MonoBehaviour
{
    public float y;
    Karakter karakter;
    void Start()
    {
        karakter = Karakter.Instance;
    }

    void Update()
    {
        if(karakter.transform.position.y-0.60f+y > transform.position.y)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -3);
        }
        else
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -1);
        }
    }
}
