using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gorev3 : GorevSistemi
{
    [Space(5)]
    [SerializeField] private GameObject geyik;

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
        CancelInvoke("Diyalog");
        diyalog = 6;
        Invoke("Diyalog", 0.1f);
    }
    IEnumerator JumpScare()
    {
        yield return new WaitForSeconds(1);
    }
}
