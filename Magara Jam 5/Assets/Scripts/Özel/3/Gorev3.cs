using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Kino;

public class Gorev3 : GorevSistemi
{
    [Space(5)]
    [SerializeField] private GameObject geyik,geyikKafasi;

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
    void BuSahne()
    {
        SceneManager.LoadScene(3);
    }
    void GorevKontrol()
    {
        if (gorev == 0)
        {
            float mesafe = Vector3.Distance(karakter.transform.position, geyik.transform.position);
            if (mesafe < 5)
            {
                tekrarla = true;
                gorev++;
                return;
            }
            if (!tekrarla) return;
            Invoke("Diyalog", 1f);
            tekrarla = false;
        }
        if (gorev == 1)
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
        transform.GetChild(0).GetComponent<AudioSource>().Stop();
        yield return new WaitForSeconds(4);
        geyik.SetActive(false);
        yield return new WaitForSeconds(2);
        geyikKafasi.SetActive(true);
        transform.GetChild(1).GetComponent<AudioSource>().Play();
        Camera.main.GetComponent<DigitalGlitch>().intensity = 0.6f;
        Camera.main.GetComponent<AnalogGlitch>().scanLineJitter = 0.63f;
        Camera.main.GetComponent<AnalogGlitch>().verticalJump = 0.12f;
        Camera.main.GetComponent<AnalogGlitch>().horizontalShake = 0.12f;
        Camera.main.GetComponent<AnalogGlitch>().colorDrift = 0.5f;
        yield return new WaitForSeconds(1.5f);
        Perde.Instance.Karart();
        Invoke("BuSahne", 2);
    }
}
