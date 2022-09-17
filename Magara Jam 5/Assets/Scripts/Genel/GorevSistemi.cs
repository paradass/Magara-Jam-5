using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GorevSistemi : MonoBehaviour
{
    [TextArea(3,5)]
    [SerializeField] public string[] yazilar;
    [System.NonSerialized] public Text yazi;
    [System.NonSerialized] public Karakter karakter;
    public void Start()
    {
        yazi = GameObject.Find("Gorev Yazisi").GetComponent<Text>();
        karakter = Karakter.Instance;
    }
}
