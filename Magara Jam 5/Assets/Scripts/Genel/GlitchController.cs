using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kino;

public class GlitchController : MonoBehaviour
{
    public DigitalGlitch dg;
    public AnalogGlitch ag;


   void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "GlitchTrigger")
        {
            dg.intensity = 0.5f;
            ag.verticalJump = 0.5f;
            ag.scanLineJitter = 0.5f;
            ag.horizontalShake = 0.5f;
            ag.colorDrift = 0.5f;
        }
    }
    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.tag == "GlitchTrigger")
        {
            dg.intensity = 0;
            ag.verticalJump = 0;
            ag.scanLineJitter = 0.03f;
            ag.horizontalShake = 0;
            ag.colorDrift = 0;
        }
    }
}
