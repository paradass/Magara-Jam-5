using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Menucontroller : MonoBehaviour
{
    public AudioSource ad;
    public AudioSource music;
    public AudioSource music2,bozulmaSesi;

    public bool coruntineController=false;

    void Start()
    {
        music.Play();
        StartCoroutine(TwentySeconds());
    }



    public void Oyunbasla()
    {
        SceneManager.LoadScene(1);
        ad.Play();
    }
    public void cýkýs()
    {
        Application.Quit();
        ad.Play();
    }
    IEnumerator TwentySeconds()
    {

        yield return new WaitForSeconds(18f);
        music.Stop();
        bozulmaSesi.Play();
        yield return new WaitForSeconds(1f);
        music2.Play();
    }
}
