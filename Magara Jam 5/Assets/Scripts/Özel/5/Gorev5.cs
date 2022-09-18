using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Kino;
public class Gorev5 : GorevSistemi
{
    [Space(5)]
    [SerializeField] Vector3 hedef;
    [SerializeField] GameObject[] hayaletler;
    [SerializeField] GameObject geyikKafasi;
    public bool golgelendi;
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
        SceneManager.LoadScene(2);
    }
    void GorevKontrol()
    {
        if (gorev == 0)
        {
            float mesafe = Vector3.Distance(karakter.transform.position, hedef);
            if (mesafe < 3)
            {
                tekrarla = true;
                gorev++;
                return;
            }
            if (!tekrarla) return;
            Invoke("Diyalog", 1);
            tekrarla = false;

        }
        if (gorev == 1)
        {
            if (golgelendi)
            {
                tekrarla = true;
                gorev++;
                StartCoroutine(Son());
                return;
            }
            if (!tekrarla) return;
            Invoke("GolgeCikar", 1);
            CancelInvoke("Diyalog");
            diyalog = 4;
            Invoke("Diyalog", 1);
            tekrarla = false;
        }
    }

    void GolgeCikar()
    {
        hayaletler[0].SetActive(true);
        hayaletler[1].SetActive(true);
    }

    IEnumerator Son()
    {
        CancelInvoke("Diyalog");
        transform.GetChild(0).GetComponent<AudioSource>().Stop();
        hayaletler[0].SetActive(false);
        hayaletler[1].SetActive(false);

        transform.GetChild(2).GetComponent<AudioSource>().Play();
        Camera.main.GetComponent<DigitalGlitch>().intensity = 0.2f;
        Camera.main.GetComponent<AnalogGlitch>().scanLineJitter = 0.23f;
        Camera.main.GetComponent<AnalogGlitch>().verticalJump = 0.06f;
        Camera.main.GetComponent<AnalogGlitch>().horizontalShake = 0.06f;
        Camera.main.GetComponent<AnalogGlitch>().colorDrift = 0.2f;
        yield return new WaitForSeconds(2);
        //ekran temiz
        Camera.main.GetComponent<DigitalGlitch>().intensity = 0f;
        Camera.main.GetComponent<AnalogGlitch>().scanLineJitter = 0f;
        Camera.main.GetComponent<AnalogGlitch>().verticalJump = 0f;
        Camera.main.GetComponent<AnalogGlitch>().horizontalShake = 0f;
        Camera.main.GetComponent<AnalogGlitch>().colorDrift = 0f;
        CancelInvoke("Diyalog");
        diyalog = 15;
        Invoke("Diyalog", 1);


        transform.GetChild(0).GetComponent<AudioSource>().Stop();
        yield return new WaitForSeconds(4);
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
    }
}
