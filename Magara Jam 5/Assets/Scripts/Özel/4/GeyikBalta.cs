using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeyikBalta : MonoBehaviour
{
    void Update()
    {
        float mesafe = Vector3.Distance(transform.position, Karakter.Instance.transform.position);
        if (mesafe < 3 && Karakter.Instance.vurma)
        {
            Karakter.Instance.baltaVarmi = true;
            Destroy(gameObject);
        }
    }
}
