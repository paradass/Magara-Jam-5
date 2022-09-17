using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitPush : MonoBehaviour
{
    public bool solust;
    public bool sagust;
    public bool solalt;
    public bool sagalt;
    public bool innit;
    void OnTriggerEnter2D(Collider2D collider)
    {

        if (collider.tag == "1")
        {
            solust = true;
           innit =true;
}
        else if (collider.tag == "2")
        {
            sagust = true;
            innit = true;
        }
       else if (collider.tag == "3")
        {
            solalt = true;
            innit = true;
        }
        else if (collider.tag == "4")
        {
            sagalt = true;
            innit = true;
        }
    }
    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.tag == "1")
        {
            solust = false;
            innit = false;
        }
        if (collider.tag == "2")
        {
            sagust = false;
            innit = false;
        }
        if (collider.tag == "3")
        {
            solalt = false;
            innit = false;
        }
        if (collider.tag == "4")
        {
            sagalt = false;
            innit = false;
        }
    }
}
