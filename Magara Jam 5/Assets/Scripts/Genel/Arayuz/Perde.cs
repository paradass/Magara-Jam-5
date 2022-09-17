using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Perde : MonoBehaviour
{
    private static Perde _instance;
    public static Perde Instance => _instance;

    public bool aydinlatimmi;
    Animator animator;

    private void Awake()
    {
        _instance = this;
    }
    void Start()
    {
        animator = GetComponent<Animator>();
        if(aydinlatimmi) Aydinlat();
    }
    
    public void Aydinlat()
    {
        animator.Play("Aydinlan");
    }

    public void Karart()
    {
        animator.Play("Karart");
    }
}
