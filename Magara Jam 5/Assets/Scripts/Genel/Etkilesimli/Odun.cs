using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Odun : MonoBehaviour
{
    [SerializeField] private bool renk;
    [SerializeField] private Sprite[] sprites;
    private AudioSource almaSesi;
    SpriteRenderer gorsel;
    bool alindi;
    void Start()
    {
        almaSesi = GetComponent<AudioSource>();
        gorsel = transform.GetChild(0).GetComponent<SpriteRenderer>();
        if (renk) gorsel.sprite = sprites[0];
        else gorsel.sprite = sprites[1];
    }
    void Update()
    {
        if (alindi) return;
        float mesafe = Vector3.Distance(transform.position, Karakter.Instance.transform.position);
        if (mesafe < 3 && Karakter.Instance.vurma)
        {
            alindi = true;
            Destroy(gorsel.gameObject);
            almaSesi.Play();
            Karakter.Instance.odunSayisi++;
            GetComponent<BoxCollider2D>().isTrigger = true;
            Destroy(gameObject, 2);
        }
    }
}
