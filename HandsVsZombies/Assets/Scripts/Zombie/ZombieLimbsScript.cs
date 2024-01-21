using Microsoft.MixedReality.Toolkit.Input;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieLimbsScript : MonoBehaviour
{
    [SerializeField] private Renderer[] limbRenderer;
    [SerializeField] private GameObject replacementObject;
    private CharacterJoint characterJoint;
    [SerializeField] private float breakForce = 1000f;

    public bool isLeg;
    private bool broken = false;
    private GrabAbleItem grabAbleItem = null; //Wenn != null dann ist das das Körperteil in der Hand
    private SpherePointer spherePointer;


    private void Start()
    {
        characterJoint = GetComponent<CharacterJoint>();
        grabAbleItem = GetComponent<GrabAbleItem>();
    }

    private void Update()
    {
        //Der Joint Kann brechen wenn er auch gegrabt ist
        if (grabAbleItem.IsGrabbed)
        {
            if (characterJoint.currentForce.magnitude > breakForce)
            {
                DisableLimb();
            }

            if (characterJoint.currentTorque.magnitude > breakForce)
            {
                DisableLimb();
            }
        }
    }

    void OnJointBreak(float breakForce)
    {
        DisableLimb();
        if (isLeg)
        {
            //transform.root.GetComponent<ZombieScript>().LoseLeg();
        }
    }

    private void OnDestroy()
    {
        
    }

    public void DisableLimb()
    {
        if (!broken && spherePointer != null)
        {
            broken = true;
            Debug.Log("break!");
            ZombieLimbsScript[] characterJointyList = GetComponentsInChildren<ZombieLimbsScript>();

            foreach (var limb in limbRenderer)
            {
                limb.gameObject.SetActive(false);
            }

            replacementObject.gameObject.SetActive(true);
            replacementObject.transform.SetParent(null);
            replacementObject.GetComponent<GrabAbleItem>().GrabItem(spherePointer);

            grabAbleItem.FreeItem();
        }
    }

    public void Grabbed(SpherePointer pointer)
    {
        spherePointer = pointer;
    }

    public void Released()
    {
        spherePointer = null;
    }
}
