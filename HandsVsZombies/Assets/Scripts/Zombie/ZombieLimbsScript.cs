using Microsoft.MixedReality.Toolkit.Input;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieLimbsScript : MonoBehaviour
{
    [SerializeField] private Renderer[] limbRenderer;
    [SerializeField] private GameObject[] replacementList;
    private CharacterJoint characterJoint;
    [SerializeField] private float breakForce = 1000f;

    public GameObject[] ReplacementList => replacementList;
    public bool isLeg;
    private bool broken = false;
    private Transform grabParent = null; //Wenn != null dann ist das das Körperteil in der Hand
    private Transform oldParent = null;
    private GrabAbleItem grabAbleItem = null;

    private void Start()
    {
        characterJoint = GetComponent<CharacterJoint>();
        grabAbleItem = GetComponent<GrabAbleItem>();
        oldParent = transform.parent;
    }

    private void Update()
    {
        //Der Joint Kann brechen wenn er auch gegrabt ist
        if (grabParent != null)
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
        if (!broken)
        {
            broken = true;
            Debug.Log("break!");
            ZombieLimbsScript[] characterJointyList = GetComponentsInChildren<ZombieLimbsScript>();

            foreach (var limb in limbRenderer)
            {
                limb.gameObject.SetActive(false);
            }

            foreach (var replacement in ReplacementList)
            {
                replacement.gameObject.SetActive(true);
                replacement.transform.SetParent(grabParent.transform);
                if(grabParent != null )
                {
                    grab
                }
                //replacement.transform.position = transform.position;
            }
            transform.parent = oldParent;
        }
    }

    public void Grabbed(Transform parent)
    {
        grabParent = parent;
    }

    public void Released()
    {
        grabParent = null;
    }
}
