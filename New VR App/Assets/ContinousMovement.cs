using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class ContinousMovement : MonoBehaviour
{
    public XRNode inputSource;

    public XRNode headsetNode;
    public float gravity = -9.81f;
    private float fallingSpeed = 10.0f;
    private Vector2 inputAxis;

    private Quaternion headsetRotation;
    private XRRig xrRig;



    public float speed = 1;

    private CharacterController character;
    // Start  called before the first frame update
    void Start()
    {
        character = GetComponent<CharacterController>();
        xrRig = GetComponent<XRRig>();
    }

    // Update is called once per frame
    void Update()
    {
        InputDevice device = InputDevices.GetDeviceAtXRNode(inputSource);
        InputDevice headset = InputDevices.GetDeviceAtXRNode(headsetNode);
        headset.TryGetFeatureValue(CommonUsages.centerEyeRotation, out headsetRotation);
        

        device.TryGetFeatureValue(CommonUsages.primary2DAxis, out inputAxis);
    }

    private void FixedUpdate()
    {
        Quaternion headNYaw = Quaternion.Euler(0, xrRig.cameraGameObject.transform.rotation.eulerAngles.y, 0);
        Vector3 direction =  headNYaw * new Vector3(inputAxis.x, 0, inputAxis.y);
        if ( isGrounded())
        {
            fallingSpeed = 0;
        }
        else 
        {
            fallingSpeed += gravity*Time.fixedDeltaTime;
        }
        character.Move(direction *Time.fixedDeltaTime * speed);
    }

    private bool isGrounded()
    {
        if 
    }
}
