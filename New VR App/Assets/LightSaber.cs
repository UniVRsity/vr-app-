using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSaber : MonoBehaviour
{
    // Start is called before the first frame update

    // Update is called once per frame
   private Animator LightSaberAnimator;
   void Start()
    {
        LightSaberAnimator = GetComponent<Animator>();
    }

    public void GrowLightSaber()
    {
        LightSaberAnimator.SetTrigger("GrowSaber");
        LightSaberAnimator.ResetTrigger("ShrinkSaber");
    }
    public void ShrinkLightSaber()
    {
        LightSaberAnimator.SetTrigger("ShrinkSaber");
        LightSaberAnimator.ResetTrigger("GrowSaber");
    }
}
