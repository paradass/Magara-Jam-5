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
    }

    void Update()
    {
        if (!coruntineController)
        {
            StartCoroutine(TwentySeconds());
        }
        if (coruntineController)
        {
            music.Pause();
            music2.Play();
        }
        
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

        yield return new WaitForSeconds(20f);
        coruntineController = true;
    }
}
