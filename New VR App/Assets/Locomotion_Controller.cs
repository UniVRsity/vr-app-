using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
public class Locomotion_Controller : MonoBehaviour
{
    public XRController leftTeleportRay;
    public XRController rightTeleportRay;
    public InputHelpers.Button teleportActivationButton;
    public float activationThreshold = 0.2f;

    
    public bool checkIfActivated(XRController controller)
    {
        InputHelpers.IsPressed(controller.inputDevice, teleportActivationButton, out bool isActivated, activationThreshold);
        return isActivated;
    }

    // Update is called once per frame
    void Update()
    {
        if (leftTeleportRay)
        {
            if (checkIfActivated(leftTeleportRay))
            {
                StartCoroutine("DelayLeft");
            }
        }
        if (rightTeleportRay)
        {
        if (checkIfActivated(rightTeleportRay))
        {
            StartCoroutine("DelayRight");
        }
    }
}

IEnumerator DelayLeft()
{
    yield return new WaitForSeconds(0.01f);
    leftTeleportRay.gameObject.SetActive(checkIfActivated(leftTeleportRay));
}

IEnumerator DelayRight()
{
    yield return new WaitForSeconds(0.01f);
    rightTeleportRay.gameObject.SetActive(checkIfActivated(rightTeleportRay));
}

}
