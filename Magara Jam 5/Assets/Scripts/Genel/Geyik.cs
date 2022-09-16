using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Geyik : MonoBehaviour,IEtkilesim
{
    private AudioSource olmeSesi;
    Animator animator;
    bool oldumu;

    public void Etkiles()
    {
        Invoke("Ol", 0.3f);
    }
    void Ol()
    {
        if (oldumu) return;
        oldumu = true;
        animator.Play("Geyik Ol");
        olmeSesi.Play();
    }
    void Start()
    {
        animator = transform.GetChild(0).GetComponent<Animator>();
        olmeSesi = GetComponent<AudioSource>();
    }
}
