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
                diyalog = 15;
                Invoke("Diyalog", 0.1f);
                StartCoroutine(Son());
                return;
            }
            if (!tekrarla) return;
            Invoke("GolgeCikar", 1);
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
        hayaletler[0].SetActive(false);
        hayaletler[1].SetActive(false);
        yield return new WaitForSeconds(10);

    }
}
