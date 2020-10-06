using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class gun : MonoBehaviour
{
    public XRNode inputSource;


    public GameObject bullet;
    public Transform barrel;
    public float speed; 

    public AudioSource audioSource;

    public void fireGun(){
        bullet = Instantiate(bullet, barrel.position, barrel.rotation);
        bullet.GetComponent<Rigidbody>().AddForce(barrel.forward*speed, ForceMode.Impulse);
        audioSource.Play();
    }
    // Update is called once per frame
    // void FixedUpdate()
    // {
    //     InputDevice device = InputDevices.GetDeviceAtXRNode(inputSource);
    //     device.TryGetFeatureValue(CommonUsages.triggerButton, out triggerPressed);
    //     device.TryGetFeatureValue(CommonUsages.triggerButton, out gripPressed);
    //     if (gripPressed && triggerPressed&& newPress){
    //         newPress = false;
    //         fireGun();
    //         Debug.Log("Fired");
    //     }
    //     else{
    //         newPress = true;
    //     }
    // }
}
