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
    [HideInInspector] public SpherePointer grabber;
    public UnityEvent OnGrabbtUp;
    public UnityEvent OnGrabbtDown;
    private bool isGrabbed = false;
    private ZombieLimbsScript zombieLimbsScript = null;

    public bool IsGrabbed { get => isGrabbed; set => isGrabbed = value; }

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
        parent = transform.parent;
        zombieLimbsScript = GetComponent<ZombieLimbsScript>();
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

        GrabItem(spherePointer);
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

        FreeItem();
    }
    
    //Plaziert das Item in der Hand
    public void GrabItem(SpherePointer spherePointer)
    {
        if (body == null)
        {
            body = GetComponent<Rigidbody>();
        }
        grabber = spherePointer;
        body.isKinematic = true;
        transform.parent = spherePointer.transform;

        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;

        isGrabbed = true;
        OnGrabbtDown.Invoke();
        Debug.Log("Grabb: " + spherePointer.PointerName);

        if (zombieLimbsScript != null)
        {
            zombieLimbsScript.Grabbed(spherePointer);
        }
    }

    //Befreie das Item von der Hand
    public void FreeItem()
    {
        if(body == null)
        {
            body = GetComponent<Rigidbody>();
        }
        grabber = null;
        isGrabbed = false;
        transform.parent = parent;
        body.isKinematic = false;
        body.AddForce(velocity, ForceMode.VelocityChange);
        lastPosition = null;
        OnGrabbtUp.Invoke();

        if (zombieLimbsScript != null)
        {
            zombieLimbsScript.Released();
        }
    }

    public void OnPointerClicked(MixedRealityPointerEventData eventData)
    {
        //throw new System.NotImplementedException();
    }
}
