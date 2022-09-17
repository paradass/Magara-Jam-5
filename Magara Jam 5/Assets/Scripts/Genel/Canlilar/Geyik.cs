using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Geyik : MonoBehaviour,IEtkilesim
{
    private AudioSource olmeSesi;
    Animator animator;
    bool oldumu;

    void Start()
    {
        animator = transform.GetChild(0).GetComponent<Animator>();
        olmeSesi = GetComponent<AudioSource>();
    }
    public void Etkiles()
    {
        if (!Karakter.Instance.baltaVarmi) return;
        Invoke("Ol", 0.3f);
    }
    void Ol()
    {
        if (oldumu) return;
        oldumu = true;
        animator.Play("Geyik Ol");
        olmeSesi.Play();
        Destroy(this, 2);
    }
}
