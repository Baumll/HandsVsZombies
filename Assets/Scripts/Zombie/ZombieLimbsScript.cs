using Microsoft.MixedReality.Toolkit.Input;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GrabAbleItem))]
public class ZombieLimbsScript : MonoBehaviour
{
    //Sorgt dafür das dieser Körperteil abtrennbar ist

    [SerializeField] private Renderer[] limbRenderer;
    [SerializeField] private GameObject replacementObject = null;
    private CharacterJoint characterJoint;
    [SerializeField] private float breakForce = 100f;

    public bool isCrucial; //Wenn true dann stribt der Zombie nach der Abtrennung
    public bool isLeg;
    private bool broken = false;
    private GrabAbleItem grabAbleItem = null; 
    private SpherePointer spherePointer; //Wenn != null dann ist das das K�rperteil in der Hand
    private ZombieController topMostParent;


    private void Start()
    {
        characterJoint = GetComponent<CharacterJoint>();
        grabAbleItem = GetComponent<GrabAbleItem>();
        topMostParent = GetComponentInParent<ZombieController>();
    }

    private void Update()
    {
        //Der Joint Kann brechen wenn er auch gegrabt ist und zu viel Kraft drauf ist
        if (grabAbleItem.IsGrabbed)
        {
            if (characterJoint.currentForce.magnitude > breakForce)
            {
                DisableLimb();
                return;
            }

            if (characterJoint.currentTorque.magnitude > breakForce)
            {
                DisableLimb();
                return;
            }
        }
    }

    void OnJointBreak(float breakForce)
    {
        DisableLimb();
        if (isCrucial)
        {
            //transform.root.GetComponent<ZombieController>().LoseLeg();
        }
    }

    private void OnDestroy()
    {
        
    }

    public void DisableLimb()
    {
        //if (spherePointer == null) return;
        if (broken) return;

        broken = true;
        ZombieLimbsScript[] characterJointyList = GetComponentsInChildren<ZombieLimbsScript>();

        //Deaktiviert die abgetrennten Gliedmaßen
        foreach (var limb in limbRenderer)
        {
            limb.gameObject.SetActive(false);
        }

        //Hier soll eigentlich die Abgetrennte Gliedmaße Erstellt werden Aber das funktioniert nicht so wie gewollt.

        //if (replacementObject is not null)
        //{
        //    replacementObject.gameObject.SetActive(true);
        //    replacementObject.transform.SetParent(null);
        //    replacementObject.GetComponent<GrabAbleItem>().GrabItem(spherePointer);
        //}
            
        grabAbleItem.FreeItem();
        //gameObject.SetActive(false);

        if (isCrucial)
        {
            topMostParent.Kill();
        }
        if (isLeg)
        {
            topMostParent.LoseLeg();
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
