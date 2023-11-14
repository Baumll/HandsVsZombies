using System.Collections;
using System.Collections.Generic;
using Microsoft.MixedReality.Toolkit.Input;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(NearInteractionGrabbable), typeof(Rigidbody))]
public class GrabAbleItem : MonoBehaviour, IMixedRealityPointerHandler
{

    private Rigidbody body;
    private Transform parent;
    private Vector3 ? lastPosition;
    private Vector3 velocity;
    private SpherePointer grabber;
    public UnityEvent OnGrabbt;
    private bool isGrabbed = false;

    public bool IsGrabbed { get => isGrabbed; set => isGrabbed = value; }

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
        parent = transform.parent;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 position = transform.position;
        if (lastPosition.HasValue)
        {
            velocity = (position - lastPosition.Value) / Time.fixedDeltaTime;
        }

        lastPosition = position;
    }

    public void OnPointerDown(MixedRealityPointerEventData eventData)
    {
        IMixedRealityPointer mixedRealityPointer = eventData.Pointer;
        SpherePointer spherePointer = (SpherePointer)mixedRealityPointer;

        if (spherePointer == null)
        {
            return;
        }

        grabber = spherePointer;
        body.isKinematic = true;
        transform.parent = spherePointer.transform;

        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;

        isGrabbed = true;
        OnGrabbt.Invoke();
        Debug.Log("Grabb: " + spherePointer.PointerName);
    }

    public void OnPointerDragged(MixedRealityPointerEventData eventData)
    {
        //throw new System.NotImplementedException();
    }

    public void OnPointerUp(MixedRealityPointerEventData eventData)
    {
        IMixedRealityPointer mixedRealityPointer = eventData.Pointer;
        SpherePointer spherePointer = (SpherePointer)mixedRealityPointer;

        if (spherePointer == null || grabber != spherePointer)
        {
            return;
        }

        grabber = null;
        isGrabbed = false;
        transform.parent = parent;
        body.isKinematic = false;
        body.AddForce(velocity, ForceMode.VelocityChange);
        lastPosition = null;
    }

    public void OnPointerClicked(MixedRealityPointerEventData eventData)
    {
        //throw new System.NotImplementedException();
    }
}
