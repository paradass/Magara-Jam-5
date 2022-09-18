using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Kino;

public class Gorev4 : GorevSistemi
{
    [Space(5)]
    [SerializeField] private Sprite kotuUi;
    [SerializeField] private GameObject geyik,yaratik,geyikKafasi;
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
        SceneManager.LoadScene(5);
    }
    void GorevKontrol()
    {
        if (gorev == 0)
        {
            if (karakter.baltaVarmi)
            {
                CancelInvoke("Diyalog");
                YaziKapat(true, true);
                StartCoroutine(JumpScare());
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
            float mesafe = Vector3.Distance(karakter.transform.position, hedef);
            if (mesafe < 5)
            {
                Perde.Instance.Karart();
                Invoke("SonrakiSahne", 2);
                tekrarla = true;
                gorev++;
                return;
            }
            if (!tekrarla) return;
            diyalog = 5;
            Invoke("Diyalog", 1f);
            tekrarla = false;
        }
    }
    IEnumerator JumpScare()
    {
        //transform.GetChild(1).GetComponent<AudioSource>().Play();
        //geyikKafasi.SetActive(true);
        transform.GetChild(0).GetComponent<AudioSource>().Pause();
        yield return new WaitForSeconds(2);
        //glitch
        transform.GetChild(2).GetComponent<AudioSource>().Play();
        Camera.main.GetComponent<DigitalGlitch>().intensity = 0.2f;
        Camera.main.GetComponent<AnalogGlitch>().scanLineJitter = 0.23f;
        Camera.main.GetComponent<AnalogGlitch>().verticalJump = 0.06f;
        Camera.main.GetComponent<AnalogGlitch>().horizontalShake = 0.06f;
        Camera.main.GetComponent<AnalogGlitch>().colorDrift = 0.2f;
        yield return new WaitForSeconds(2);
        //ekran temiz
        transform.GetChild(0).GetComponent<AudioSource>().Play();
        GameObject.Find("Odun Toplama").GetComponent<Image>().sprite = kotuUi;
        Camera.main.GetComponent<DigitalGlitch>().intensity = 0f;
        Camera.main.GetComponent<AnalogGlitch>().scanLineJitter = 0f;
        Camera.main.GetComponent<AnalogGlitch>().verticalJump = 0f;
        Camera.main.GetComponent<AnalogGlitch>().horizontalShake = 0f;
        Camera.main.GetComponent<AnalogGlitch>().colorDrift = 0f;
        yield return new WaitForSeconds(2);
        //glitch
        transform.GetChild(0).GetComponent<AudioSource>().Pause();
        GameObject[] agacalar = GameObject.FindGameObjectsWithTag("Agac");
        foreach(GameObject obje in agacalar)
        {
            Instantiate(geyik, obje.transform.position, Quaternion.identity);
            Destroy(obje);
        }
        transform.GetChild(2).GetComponent<AudioSource>().Play();
        Camera.main.GetComponent<DigitalGlitch>().intensity = 0.2f;
        Camera.main.GetComponent<AnalogGlitch>().scanLineJitter = 0.23f;
        Camera.main.GetComponent<AnalogGlitch>().verticalJump = 0.06f;
        Camera.main.GetComponent<AnalogGlitch>().horizontalShake = 0.06f;
        Camera.main.GetComponent<AnalogGlitch>().colorDrift = 0.2f;
        yield return new WaitForSeconds(2);
        //ekran temiz
        transform.GetChild(0).GetComponent<AudioSource>().Play();
        Camera.main.GetComponent<DigitalGlitch>().intensity = 0f;
        Camera.main.GetComponent<AnalogGlitch>().scanLineJitter = 0f;
        Camera.main.GetComponent<AnalogGlitch>().verticalJump = 0f;
        Camera.main.GetComponent<AnalogGlitch>().horizontalShake = 0f;
        Camera.main.GetComponent<AnalogGlitch>().colorDrift = 0f;
        yield return new WaitForSeconds(10);
        transform.GetChild(0).GetComponent<AudioSource>().Stop();
        Destroy(Instantiate(yaratik, new Vector3(karakter.transform.position.x - 3, karakter.transform.position.y, -6), Quaternion.identity), 2);
        yield return new WaitForSeconds(2);
        transform.GetChild(1).GetComponent<AudioSource>().Play();
        geyikKafasi.SetActive(true);
        Camera.main.GetComponent<DigitalGlitch>().intensity = 0.6f;
        Camera.main.GetComponent<AnalogGlitch>().scanLineJitter = 0.63f;
        Camera.main.GetComponent<AnalogGlitch>().verticalJump = 0.12f;
        Camera.main.GetComponent<AnalogGlitch>().horizontalShake = 0.12f;
        Camera.main.GetComponent<AnalogGlitch>().colorDrift = 0.5f;

        yield return new WaitForSeconds(2);
        geyikKafasi.SetActive(false);
        Camera.main.GetComponent<DigitalGlitch>().intensity = 0f;
        Camera.main.GetComponent<AnalogGlitch>().scanLineJitter = 0f;
        Camera.main.GetComponent<AnalogGlitch>().verticalJump = 0f;
        Camera.main.GetComponent<AnalogGlitch>().horizontalShake = 0f;
        Camera.main.GetComponent<AnalogGlitch>().colorDrift = 0f;
        yield return new WaitForSeconds(1);
        devamEt = true;

    }
}
