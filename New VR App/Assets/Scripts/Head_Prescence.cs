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
        List<InputDevice> allDevices = new List<InputDevice>();
        InputDevices.GetDevices(allDevices);
        foreach (var device in allDevices)
        {
            Debug.Log(string.Format("Device found with name '{0}' and role '{1}'", 
              device.name, device.characteristics.ToString()));
        }
    }

    void tryInitialize()
    {
        List<InputDevice> devices = new List<InputDevice>();
        List<InputDevice> allDevices = new List<InputDevice>();
        InputDevices.GetDevicesWithCharacteristics(headsetCharacteristics, devices);
        InputDevices.GetDevices(allDevices);

    }

    // Update is called once per frame
    void Update()
    {

    }
}
