using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieLimbsScript : MonoBehaviour
{

    public GameObject[] renderer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnJointBreak(float breakForce)
    {
        disableLimb();
    }


    public void disableLimb()
    {
        Debug.Log("break!");
        ZombieLimbsScript[] characterJointyList = GetComponentsInChildren<ZombieLimbsScript>();

        foreach(var joint in characterJointyList)
        {
            joint.disableLimb();
        }

        foreach (var limb in renderer)
        {
            limb.SetActive(false);
        }
        Destroy(gameObject);
    }
}
