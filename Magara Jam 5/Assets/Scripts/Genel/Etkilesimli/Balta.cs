using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balta : MonoBehaviour
{
    [SerializeField] private bool renk;
    [SerializeField] private Sprite[] sprites;
    private AudioSource almaSesi;
    SpriteRenderer gorsel;
    bool alindi;
    void Start()
    {
        almaSesi = GetComponent<AudioSource>();
        gorsel = GetComponent<SpriteRenderer>();
        if (renk) gorsel.sprite = sprites[0];
        else gorsel.sprite = sprites[1];
    }
    void Update()
    {
        if (alindi) return;
        float mesafe = Vector3.Distance(transform.position, Karakter.Instance.transform.position);
        if (mesafe < 2 && Karakter.Instance.vurma)
        {
            alindi = true;
            Karakter.Instance.baltaVarmi = true;
            almaSesi.Play();
            if (renk) gorsel.sprite = sprites[2];
            else gorsel.sprite = sprites[3];
        }
    }
}
