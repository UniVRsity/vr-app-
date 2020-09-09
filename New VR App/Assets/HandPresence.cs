using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class HandPresence : MonoBehaviour
{
    private InputDevice targetDevice;
    public List<GameObject> controllerPrefabs;
    private GameObject spawnController;
    // Start is called before the first frame update
    void Start()
    {
      List<InputDevice> devices = new List<InputDevice>();
      InputDeviceCharacteristics rightControllerCharacteristics = InputDeviceCharacteristics.Right | InputDeviceCharacteristics.Controller;
      InputDevices.GetDevicesWithCharacteristics(rightControllerCharacteristics, devices);

      foreach( var item in devices)
      {
          Debug.Log(item.name+item.characteristics);
      }

      if (devices.Count > 0)
      {
        targetDevice = devices[0];
        GameObject prefab = controllerPrefabs.Find(controller => controller.name == targetDevice.name);
        if (prefab)
        {
          spawnController = Instantiate(prefab, transform);
        }
        else
        {
          Debug.LogError("Did not find corresponding controller model");
          spawnController = Instantiate(controllerPrefabs[0], transform);

        }
      }

    }

    // Update is called once per frame
    void Update()
    {
        if (targetDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool primaryButtonValue) && primaryButtonValue)
        {
          Debug.Log("Primary Button is pressed");
        }
        
        if (targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue))
        {
          Debug.Log(triggerValue);
        }
        
        if(targetDevice.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 primary2DAxisValue))
        {
          Debug.Log("primary touch pad value" + primary2DAxisValue);
        }

    }
}
