using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Menucontroller : MonoBehaviour
{
    public AudioSource ad;
    public AudioSource music;
    public AudioSource music2;

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
    public void c�k�s()
    {
        Application.Quit();
        ad.Play();
    }
    IEnumerator TwentySeconds()
    {

        yield return new WaitForSeconds(20f);
        music.Stop();
        music2.Play();
    }
}
