using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agac : MonoBehaviour,IEtkilesim
{
    [SerializeField] private bool agacRengi;
    [SerializeField] private GameObject odun;
    [SerializeField] AudioSource vurmaSesi, dusmeSesi;
    int can = 3;
    bool dus,sagami;

    void Start()
    {
        transform.GetChild(0).gameObject.SetActive(false);
        transform.GetChild(1).gameObject.SetActive(false);
        if (agacRengi) transform.GetChild(0).gameObject.SetActive(true);
        else transform.GetChild(1).gameObject.SetActive(true);
    }
    private void Update()
    {
        Dus();
    }
    public void Etkiles()
    {
        if (!Karakter.Instance.baltaVarmi || can <= 0) return;
        can--;
        if(can > 0)
        {
            Invoke("Yamul", 0.4f);
        }
        else
        {
            Invoke("DusAktifles", 0.4f);
            Invoke("OdunaDonus", 2f);
        }
    }

    void DusAktifles()
    {
        dusmeSesi.Play();
        dus = true;
    }
    void OdunaDonus()
    {
        GameObject cOdun = Instantiate(odun, transform.GetChild(4).transform.position, transform.rotation);
        if (!sagami) cOdun.transform.localScale = new Vector3(-10, 10, 10);
        Destroy(gameObject);
    }

    void Yamul()
    {
        vurmaSesi.Play();
        if (Karakter.Instance.transform.position.x > transform.position.x)
        {
            float z = transform.rotation.eulerAngles.z;
            transform.rotation = Quaternion.Euler(0, 0, z + 2);
            sagami = false;
        }
        else
        {
            float z = transform.rotation.eulerAngles.z;
            transform.rotation = Quaternion.Euler(0, 0, z - 2);
            sagami = true;
        }
    }

    void Dus()
    {
        if (!dus) return;
        if (sagami) transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, -90),60*Time.deltaTime);
        else transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, 90),60*Time.deltaTime);
    }
}
