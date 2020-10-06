using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSaber : MonoBehaviour
{
    // Start is called before the first frame update

    // Update is called once per frame
    public GameObject lightSaber;
    private Animator lightSaberAnimator;
    public AudioSource audioSource;
    public AudioClip lightSaberOn;
    public AudioClip lightSaberOff;
    public AudioClip saberSwoosh;

    private Rigidbody saberRigidBody;
    private bool ready = true;

    private bool lightSaberHeld;

    void Start()
    {
        lightSaberAnimator = GetComponent<Animator>();
        saberRigidBody = lightSaber.GetComponent<Rigidbody>();
    }

    void Update()
    {
        Debug.Log(saberRigidBody.velocity.magnitude);

        if (saberRigidBody.velocity.magnitude > 0.5 && lightSaberHeld && ready)
        {
            StartCoroutine("PlayAndWait");

        }
    }

    public void GrowLightSaber()
    {
        lightSaberHeld = true;
        lightSaberAnimator.SetTrigger("GrowSaber");
        lightSaberAnimator.ResetTrigger("ShrinkSaber");
        audioSource.PlayOneShot(lightSaberOn);
    }
    public void ShrinkLightSaber()
    {
        lightSaberHeld = false;
        lightSaberAnimator.SetTrigger("ShrinkSaber");
        lightSaberAnimator.ResetTrigger("GrowSaber");
        audioSource.PlayOneShot(lightSaberOff);
    }

    private IEnumerator PlayAndWait()
    {
        audioSource.PlayOneShot(saberSwoosh);
        ready = false;
        yield return new WaitForSeconds(1f);
        ready = true;

    }
}
