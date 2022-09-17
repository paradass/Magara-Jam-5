using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GorevSistemi : MonoBehaviour
{
    [TextArea(3,5)]
    public string[] yazilar;
    public AudioClip[] sesler;
    [System.NonSerialized] public AudioSource ses;
    [System.NonSerialized] public Text yazi;
    [System.NonSerialized] public Karakter karakter;
    [System.NonSerialized] public int gorev;
    [System.NonSerialized] public bool yaziyiBastir = true;
    public void Start()
    {
        yazi = GameObject.Find("Gorev Yazisi").GetComponent<Text>();
        karakter = Karakter.Instance;
        ses = GetComponent<AudioSource>();
        yazi.text = "";
    }
    public void GoreviDegistir(int yaziNo, int sesNo,float zaman)
    {
        StartCoroutine(Gorev(yaziNo,sesNo,zaman));
    }

    public IEnumerator Gorev(int yaziNo, int sesNo, float zaman)
    {
        yield return new WaitForSeconds(zaman);
        yazi.text = yazilar[yaziNo];
        ses.Stop();
        ses.clip = sesler[sesNo];
        ses.Play();
    }
    public void GorevKapat(bool gorev,bool yaziyiBastiriAc=false,bool konusma=false)
    {
        if (gorev) yazi.text = "";
        if (yaziyiBastiriAc) yaziyiBastir = true;
        if (konusma) ses.Stop();
    }
}
