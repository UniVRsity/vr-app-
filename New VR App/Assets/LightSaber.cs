using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSaber : MonoBehaviour
{
    
    public Animator LightSaberAnimator;
    public void TurnOnLightSaber()
    {
        LightSaberAnimator.SetTrigger("Turn LightSaber On");
        LightSaberAnimator.ResetTrigger("Turn LightSaber Off");
    }

    public void TurnLightSaberOff()
    {
        LightSaberAnimator.SetTrigger("Turn LightSaber Off");
        LightSaberAnimator.ResetTrigger("Turn LightSaber On");


    }

}
