using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Karakter : MonoBehaviour
{
    private static Karakter _instance;
    public static Karakter Instance => _instance;

    public bool baltaVarmi;
    public float hareketHizi;

    private bool hareket, vurma;
    private int yon = 2;
    private float state,blend;

    Animator animator;

    private void Awake()
    {
        _instance = this;
    }
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        Animasyon();
        Hareket();
        Etkilesim();
    }

    void Animasyon()
    {
        // Baltasýzken yukari= 0, sag= 1, asagi= 2, sol= 3, Baltaliyken yukari= 10, 11,12,13
        if (vurma && baltaVarmi)
        {
            state = 2;
        }
        else if (hareket)
        {
            state = 1;
            if (baltaVarmi)
            {
                blend = yon + 10;
            }
            else
            {
                blend = yon;
            }
        }
        else
        {
            state = 0;
            if (baltaVarmi)
            {
                blend = yon + 10;
            }
            else
            {
                blend = yon;
            }
        }
        animator.SetFloat("Blend", blend);
        animator.SetFloat("State", state);
    }
    void Hareket()
    {
        bool yatayHareket = false,dikeyHareket = false;
        if(Input.GetKey(KeyCode.RightArrow) && (!vurma || !baltaVarmi))
        {
            hareket = true;
            yon = 1;
            yatayHareket = true;
            transform.localScale = new Vector3(10, 10, 10);
            transform.position += new Vector3(hareketHizi * Time.deltaTime, 0, 0);
        }
        else if(Input.GetKey(KeyCode.LeftArrow) && (!vurma || !baltaVarmi))
        {
            hareket = true;
            yon = 3;
            yatayHareket = true;
            transform.localScale = new Vector3(-10, 10, 10);
            transform.position += new Vector3(hareketHizi * Time.deltaTime*-1, 0, 0);
        }

        if(Input.GetKey(KeyCode.UpArrow) && (!vurma || !baltaVarmi))
        {
            hareket = true;
            yon = 0;
            dikeyHareket = true;
            transform.position += new Vector3(0, hareketHizi * Time.deltaTime * 1, 0);
        }
        else if(Input.GetKey(KeyCode.DownArrow) && (!vurma || !baltaVarmi))
        {
            hareket = true;
            yon = 2;
            dikeyHareket = true;
            transform.position += new Vector3(0, hareketHizi * Time.deltaTime * -1, 0);
        }

        if (!yatayHareket && !dikeyHareket) hareket = false;

    }

    void Etkilesim()
    {
        if(Input.GetKeyDown(KeyCode.Space) && !vurma)
        {
            vurma = true;
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.up, 2);
            if (yon == 0) hit = Physics2D.Raycast(transform.position, Vector2.up, 2);
            else if(yon == 1) hit = Physics2D.Raycast(transform.position, Vector2.right, 2);
            else if(yon == 2) Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y-1), Vector2.up*-1, 2);
            else hit = Physics2D.Raycast(transform.position, Vector2.right*-1, 2);
            if (baltaVarmi)
            {
                Invoke("EtkilesimReset", 0.25f);
            }
            else
            {
                Invoke("EtkilesimReset", 0.05f);
            }
            if(hit && hit.collider.TryGetComponent<IEtkilesim>(out IEtkilesim obje))
            {
                obje.Etkilses();
            }
            else
            {
                if (baltaVarmi)
                {
                    //balta savurma sesi çal
                }
            }
        }
    }

    void EtkilesimReset()
    {
        vurma = false;
    }
}
