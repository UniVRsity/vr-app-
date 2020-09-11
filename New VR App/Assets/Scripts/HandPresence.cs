using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class HandPresence : MonoBehaviour
{

    public bool showController = false;
    public InputDeviceCharacteristics controllerCharacteristics;
    public GameObject handModelPrefab;
    private InputDevice targetDevice;
    public List<GameObject> controllerPrefabs;
    private GameObject spawnController;

    private GameObject spawnedHandModel;

    private Animator handAnimator;
    // Start is called before the first frame update
    void Start()
    {
        tryInitialize();
        InvokeRepeating("sendPulse", 2,2);
    }

    void sendPulse()
    {
        targetDevice.TryGetHapticCapabilities(out HapticCapabilities capabilities);
        targetDevice.TryGetFeatureValue(CommonUsages.userPresence, out bool batteryLevel);
        // if (targetDevice.name.Contains("Left")){
        //     targetDevice.SendHapticImpulse(0,0.3f,1);
        // }
    }

    void tryInitialize()
    {
        List<InputDevice> devices = new List<InputDevice>();
        InputDevices.GetDevicesWithCharacteristics(controllerCharacteristics, devices);

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
            spawnedHandModel = Instantiate(handModelPrefab, transform);
            handAnimator = spawnedHandModel.GetComponent<Animator>();
        }

    }
    void updateHandAnimation()
    {
        if (targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue))
        {
            handAnimator.SetFloat("Trigger", triggerValue);
        }
        else
        {
            handAnimator.SetFloat("Trigger", 0);
        }
        if (targetDevice.TryGetFeatureValue(CommonUsages.grip, out float gripValue))
        {
            handAnimator.SetFloat("Grip", gripValue);
        }
        else
        {
            handAnimator.SetFloat("Grip", 0);
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (!targetDevice.isValid)
        {
            tryInitialize();
        }
        else
        {
            if (showController)
            {
                spawnedHandModel.SetActive(false);
                spawnController.SetActive(true);
            }
            else
            {
                spawnedHandModel.SetActive(true);
                spawnController.SetActive(false);
                updateHandAnimation();
            }
        }
    }
}
