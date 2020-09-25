using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class gun : MonoBehaviour
{
    public XRNode inputSource;

    public bool triggerPressed;
    public bool gripPressed;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void fireGun(){
        Debug.Log("hessre");
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        InputDevice device = InputDevices.GetDeviceAtXRNode(inputSource);
        device.TryGetFeatureValue(CommonUsages.triggerButton, out triggerPressed);
        device.TryGetFeatureValue(CommonUsages.triggerButton, out gripPressed);
        if (gripPressed && triggerPressed){
            fireGun();
        }
    }
}
