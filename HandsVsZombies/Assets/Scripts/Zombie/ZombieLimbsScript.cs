using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieLimbsScript : MonoBehaviour
{

    public GameObject[] renderer;
    public GameObject replacement;

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

        foreach (var limb in renderer)
        {
            limb.SetActive(false);
        }

        replacement.SetActive(true);

        gameObject.SetActive(false);
    }
}
