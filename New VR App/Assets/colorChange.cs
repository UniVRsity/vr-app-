using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;


public class colorChange : MonoBehaviour
{
    // Start is called before the first frame update

    // Update is called once per frame
    private InputDevice targetDevice; 
    public InputDeviceCharacteristics controllerCharacteristics;

    public Material target;


    public void tryInitialize()
    {
         List<InputDevice> devices = new List<InputDevice>();
        InputDevices.GetDevicesWithCharacteristics(controllerCharacteristics, devices);
        if (devices.Count > 0)
        {
            targetDevice = devices[0];
        }
    }
     public void changeColor()
    {
        Debug.Log("here");
        target.SetColor("_Color", Color.green);
    }
    void Update()
    {
        Debug.Log(targetDevice.isValid);
        if (!targetDevice.isValid)
        {
            tryInitialize();
        }

        if (targetDevice.TryGetFeatureValue(CommonUsages.grip, out float gripValue) && 
        targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue) && gripValue >0.5f && triggerValue >0.5f)
            {
                Debug.Log("here");
                this.changeColor();
            }
    }
}
