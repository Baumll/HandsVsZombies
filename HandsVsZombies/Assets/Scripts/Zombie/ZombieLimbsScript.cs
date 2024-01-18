using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieLimbsScript : MonoBehaviour
{
    [SerializeField] private Renderer[] renderer;
    [SerializeField] private GameObject[] replacementList;

    public Renderer[] Renderer => renderer;
    public GameObject[] ReplacementList => replacementList;
    public bool isLeg;

    void OnJointBreak(float breakForce)
    {
        disableLimb();
        if (isLeg)
        {
            //transform.root.GetComponent<ZombieScript>().LoseLeg();
        }
    }

    private void OnDestroy()
    {
        
    }

    public void disableLimb()
    {
        Debug.Log("break!");
        ZombieLimbsScript[] characterJointyList = GetComponentsInChildren<ZombieLimbsScript>();

        //foreach(var joint in characterJointyList)
        //{
        //    joint.disableLimb();
        //}

        foreach (var limb in renderer)
        {
            limb.gameObject.SetActive(false);
        }
        foreach(var replacement in ReplacementList)
        {
            replacement.gameObject.SetActive(true);
            replacement.transform.position = transform.position;
            replacement.transform.SetParent(null);
        }

        Destroy(transform);
        //gameObject.SetActive(false);
    }
}
