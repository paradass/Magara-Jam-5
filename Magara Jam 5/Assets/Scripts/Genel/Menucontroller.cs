using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Menucontroller : MonoBehaviour
{
    public AudioSource ad;

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
}
