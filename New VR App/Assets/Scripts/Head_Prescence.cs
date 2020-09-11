using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;


public class Head_Prescence : MonoBehaviour
{
    // Start is called before the first frame update

    public InputDeviceCharacteristics headsetCharacteristics;
    private InputDevice targetDevice;
    void Start()
    {
        InvokeRepeating("tryInitialize", 0, 0.5f);
    }

    void tryInitialize()
    {
        List<InputDevice> devices = new List<InputDevice>();
        InputDevices.GetDevicesWithCharacteristics(headsetCharacteristics, devices);

        if (devices.Count > 0)
        {
            targetDevice = devices[0];

            if (targetDevice.TryGetFeatureValue(CommonUsages.deviceAcceleration, out Vector3 ab))
            {
                Debug.Log("here");
                Debug.Log(ab);
            }
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
