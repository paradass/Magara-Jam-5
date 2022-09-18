using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Kino;

public class Gorev4 : GorevSistemi
{
    [Space(5)]
    [SerializeField] private GameObject geyikKafasi;
    [SerializeField] private Vector3 hedef;
    bool devamEt;

    public void Start()
    {
        base.Start();
    }
    void Update()
    {
        GorevKontrol();
    }
    void SonrakiSahne()
    {
        SceneManager.LoadScene(4);
    }
    void GorevKontrol()
    {
        if (gorev == 0)
        {
            if (karakter.baltaVarmi)
            {
                tekrarla = true;
                gorev++;
                return;
            }
            if (!tekrarla) return;
            Invoke("Diyalog", 1f);
            tekrarla = false;
        }
        if (gorev == 1 && devamEt)
        {
            if (karakter.geyikSayisi > 0)
            {
                CancelInvoke("GeyikOldurmeme");
                Perde.Instance.Karart();
                Invoke("SonrakiSahne", 2);
                tekrarla = true;
                gorev++;
                return;
            }
            if (!tekrarla) return;
            CancelInvoke("Diyalog");
            diyalog = 3;
            Invoke("Diyalog", 0.1f);
            Invoke("GeyikOldurmeme", 9);
            tekrarla = false;
        }
    }

    void GeyikOldurmeme()
    {
        if (gorev > 1) return;
        karakter.baltaVarmi = false;
        CancelInvoke("Diyalog");
        diyalog = 6;
        Invoke("Diyalog", 0.1f);
        StartCoroutine(JumpScare());
    }
    IEnumerator JumpScare()
    {
        //transform.GetChild(0).GetComponent<AudioSource>().Stop();
        yield return new WaitForSeconds(2);
        geyikKafasi.SetActive(true);
        transform.GetChild(1).GetComponent<AudioSource>().Play();
        Camera.main.GetComponent<DigitalGlitch>().intensity = 0.6f;
        Camera.main.GetComponent<AnalogGlitch>().scanLineJitter = 0.63f;
        Camera.main.GetComponent<AnalogGlitch>().verticalJump = 0.12f;
        Camera.main.GetComponent<AnalogGlitch>().horizontalShake = 0.12f;
        Camera.main.GetComponent<AnalogGlitch>().colorDrift = 0.5f;
    }
}
