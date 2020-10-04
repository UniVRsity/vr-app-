using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class XROffsetGrabInteractable : XRGrabInteractable
{
    // Start is called before the first frame update
    private Vector3 initialAttachLocalPos;
    private Quaternion initialAttachLocalRot;
    void Start()
    {
        if (!attachTransform)
        {
            GameObject grab = new GameObject("Grab Pivot");
            grab.transform.SetParent(transform, false);
            attachTransform = grab.transform;
        }
        initialAttachLocalPos = attachTransform.localPosition;
        initialAttachLocalRot  = attachTransform.localRotation;
    }

    protected override void OnSelectEnter(XRBaseInteractor interactor)
    {
        if (interactor is XRDirectInteractor){
            attachTransform.position = interactor.transform.position;
            attachTransform.rotation = interactor.transform.rotation;
        }
        base.OnSelectEnter(interactor);
    }
}
