using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class ContinousMovement : MonoBehaviour
{
    public LayerMask groundLayer;
    public float addtionalHeight = .2f;
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

    private void FixedUpdate()
    {
        capsuleFollowHeadset();
        InputDevice device = InputDevices.GetDeviceAtXRNode(inputSource);
        device.TryGetFeatureValue(CommonUsages.primary2DAxis, out inputAxis);
        Quaternion headNYaw = Quaternion.Euler(0, xrRig.cameraGameObject.transform.eulerAngles.y, 0);
        Vector3 direction =  headNYaw * new Vector3(inputAxis.x, 0, inputAxis.y);
        character.Move(direction * Time.fixedDeltaTime * speed);
        if (isGrounded())
        {
            fallingSpeed = 0;
        }
        else 
        {
            fallingSpeed += gravity*Time.fixedDeltaTime;
        }
        character.Move(Vector3.up * fallingSpeed * Time.fixedDeltaTime);
    }

    void capsuleFollowHeadset()
    {
        character.height = xrRig.cameraInRigSpaceHeight + addtionalHeight; 
        Vector3 capsuleCenter = transform.InverseTransformPoint(xrRig.cameraGameObject.transform.position);
        character.center = new Vector3(capsuleCenter.x, capsuleCenter.y/2+ character.skinWidth, capsuleCenter.z);
    }
    private bool isGrounded()
    {
        Vector3 rayStart = transform.TransformPoint(character.center);
        float rayLength = character.center.y + 0.01f;
        bool hasHit = Physics.SphereCast(rayStart, character.radius, Vector3.down, out RaycastHit hitInfo, rayLength, groundLayer);
        return hasHit;
    }
}
