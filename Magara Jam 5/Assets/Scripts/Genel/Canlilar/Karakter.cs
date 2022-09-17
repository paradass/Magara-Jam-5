using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Karakter : MonoBehaviour
{
    private static Karakter _instance;
    public static Karakter Instance => _instance;

    public bool baltaVarmi;
    public float hareketHizi;

    [System.NonSerialized] public bool vurma;
    [System.NonSerialized] public int odunSayisi,geyikSayisi;
    
    private Text odunSayisiText;
    private bool hareket;
    private int yon = 2;
    private float state,blend;

    [SerializeField] private AudioSource yurumeSesi,baltaSesi;
    [SerializeField] private AudioClip yurumeSesi1, yurumeSesi2;
    Animator animator;

    private void Awake()
    {
        _instance = this;
    }
    void Start()
    {
        animator = GetComponent<Animator>();
        odunSayisiText = GameObject.Find("OdunSayisi").GetComponent<Text>();
    }

    void Update()
    {
        Animasyon();
        Hareket();
        Etkilesim();
        OdunSay();
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

        if (yatayHareket || dikeyHareket)
        {
            if (!yurumeSesi.isPlaying)
            {
                int random = Random.Range(0, 2);
                if (random == 0) yurumeSesi.clip = yurumeSesi1;
                else yurumeSesi.clip = yurumeSesi2;
                yurumeSesi.Play();
            }
        }
        else
        {
            hareket = false;
            yurumeSesi.Stop();
        }

    }

    void Etkilesim()
    {
        if(Input.GetKeyDown(KeyCode.Space) && !vurma)
        {
            vurma = true;
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.up, 2);
            if (transform.localScale.x > 0) hit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y-0.2f), Vector2.right, 1.2f);
            else if(transform.localScale.x < 0) hit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y - 0.2f), Vector2.right*-1, 1.2f);
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
                obje.Etkiles();
            }
            else
            {
                if (baltaVarmi)
                {
                    Invoke("BaltaSesi", 0.2f);
                }
            }
        }
    }
    void BaltaSesi()
    {
        baltaSesi.Play();
    }
    void EtkilesimReset()
    {
        vurma = false;
    }

    void OdunSay()
    {
        odunSayisiText.text = odunSayisi.ToString();
    }
}
