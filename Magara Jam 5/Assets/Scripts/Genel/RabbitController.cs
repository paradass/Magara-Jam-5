using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitController : MonoBehaviour
{
    public float[] speeds;
    public Vector2[] rotations;
    public float[] times;
    public bool canChangespeedandrot = true;

    private Vector2 actualRot;
    private float actualspeed;
    private Vector3 temproraryvector;

    private bool dontstartrandomtime;
    public RabbitPush Rp;
    public float rabbitrunSpeed;

    public Vector2 Cantpassvector1;
    public Vector2 Cantpassvector2;

    public GameObject player;
    
    
    void Start()
    {
        actualRot = rotations[Random.Range(0, rotations.Length - 1)];
        actualspeed = speeds[Random.Range(0, speeds.Length - 1)];
        temproraryvector = new Vector3(transform.position.x + actualRot.x, transform.position.y + actualRot.y, transform.position.z);
    }
    
    
    
    void Update()
    {
        
        if (!dontstartrandomtime)
        {
            Randomtime();
        }
        RabbitPush();
    }


    void Randomtime()
    {
        if (Rp.innit)
        {
            actualRot = rotations[Random.Range(0, rotations.Length - 1)];
            actualspeed = speeds[Random.Range(0, speeds.Length - 1)];
            temproraryvector = new Vector3(transform.position.x + actualRot.x, transform.position.y + actualRot.y, transform.position.z);
     }
        if (canChangespeedandrot && !Rp.innit)
        {
            actualRot = rotations[Random.Range(0, rotations.Length-1)];
            actualspeed = speeds[Random.Range(0, speeds.Length-1)];
            if (temproraryvector.x >= Cantpassvector1.x)
            {
                temproraryvector = new Vector3(transform.position.x - 2, transform.position.y + actualRot.y, transform.position.z);
            }
            else if (temproraryvector.y >= Cantpassvector1.y)
            {
                temproraryvector = new Vector3(transform.position.x + actualRot.x, transform.position.y - 2, transform.position.z);
            }
            else if (temproraryvector.x <= Cantpassvector2.x)
            {
                temproraryvector = new Vector3(transform.position.x + 2, transform.position.y + actualRot.y, transform.position.z);
            }
            else if (temproraryvector.y <= Cantpassvector2.y)
            {
                temproraryvector = new Vector3(transform.position.x + actualRot.x, transform.position.y + 2, transform.position.z);
            }
            else if (temproraryvector.x<=Cantpassvector1.x&& temproraryvector.y<= Cantpassvector1.y&&temproraryvector.x>=Cantpassvector2.x&&temproraryvector.y>= Cantpassvector2.y)
            {
                temproraryvector = new Vector3(transform.position.x + actualRot.x, transform.position.y + actualRot.y, transform.position.z);
            }
            canChangespeedandrot = false;
        }

        transform.position = Vector3.MoveTowards(transform.position,temproraryvector, actualspeed * Time.deltaTime);

        if(actualRot.x>0&& actualRot.y > 0)
        {
            transform.localScale = new Vector3(1, transform.localScale.y, transform.localScale.z);
            if (transform.position.x >= temproraryvector.x && transform.position.y >= temproraryvector.y)
            {
                StartCoroutine(waiting());
            }
        }
        else if (actualRot.x > 0 && actualRot.y < 0)
        {

            transform.localScale = new Vector3(1, transform.localScale.y, transform.localScale.z);
            if (transform.position.x >= temproraryvector.x && transform.position.y <= temproraryvector.y)
            {

                StartCoroutine(waiting());
            }
        }
        else if (actualRot.x < 0 && actualRot.y < 0)
        {
            transform.localScale = new Vector3(-1, transform.localScale.y, transform.localScale.z);
            if (transform.position.x <= temproraryvector.x && transform.position.y <= temproraryvector.y)
            {
                StartCoroutine(waiting());
            }
        }
        else if (actualRot.x < 0 && actualRot.y > 0)
        {
            transform.localScale = new Vector3(-1, transform.localScale.y, transform.localScale.z);
            if (transform.position.x <= temproraryvector.x && transform.position.y >= temproraryvector.y)
            {
                StartCoroutine(waiting());
            }
        }
        else if (actualRot.x == 0 && actualRot.y == 0)
        {
            StartCoroutine(waiting());
        }
    }
    IEnumerator waiting()
    {
        dontstartrandomtime = true;
        yield return new WaitForSeconds(times[Random.Range(0, times.Length - 1)]);
        dontstartrandomtime = false;
        canChangespeedandrot = true;
    }
    void RabbitPush()
    {

        if(Rp.solust&& Rp.sagust)
        {
            transform.position = transform.position + new Vector3(0, 1 * Time.deltaTime, 0);
           
        }
        else if(Rp.solalt&& Rp.sagalt)
        {
            transform.position = transform.position + new Vector3(0, -1 * Time.deltaTime, 0);
        }
        else if (Rp.solust && Rp.solalt)
        {
            transform.position = transform.position + new Vector3(-1 * Time.deltaTime, 0, 0);
            transform.localScale = new Vector3(-1, transform.localScale.y, transform.localScale.z);
        }
        else if (Rp.sagust && Rp.sagalt)
        {
            transform.position = transform.position + new Vector3(1 * Time.deltaTime, 0, 0);

            transform.localScale = new Vector3(1, transform.localScale.y, transform.localScale.z);
        }
        else if(Rp.solust)
        {
            transform.position = transform.position + new Vector3(-rabbitrunSpeed * Time.deltaTime, 1* Time.deltaTime, 0);
            transform.localScale = new Vector3(-1, transform.localScale.y, transform.localScale.z);

        }
        else
        if (Rp.sagust)
        {
            transform.position = transform.position + new Vector3(rabbitrunSpeed * Time.deltaTime, 1* Time.deltaTime, 0);
            transform.localScale = new Vector3(1, transform.localScale.y, transform.localScale.z);
        }
        else
        if (Rp.sagalt)
        {
            transform.position = transform.position + new Vector3(rabbitrunSpeed * Time.deltaTime,-1 * Time.deltaTime, 0);
            transform.localScale = new Vector3(1, transform.localScale.y, transform.localScale.z);
        }
        else
        if (Rp.solalt)
        {
            transform.position = transform.position + new Vector3(-rabbitrunSpeed * Time.deltaTime, -1 * Time.deltaTime, 0);
            transform.localScale = new Vector3(-1, transform.localScale.y, transform.localScale.z);
        }

    }
}
