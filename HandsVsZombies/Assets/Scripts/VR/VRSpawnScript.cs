using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRSpawnScript : MonoBehaviour
{
    public GameObject vRPlaySpace;
    public GameObject Camera;

    public bool reset;

    public void OnValidate()
    {
        reset = false;
        Reset();
    }


    // Start is called before the first frame update
    private void Start()
    {
        StartCoroutine(waiter());
    }
    
    private void Reset()
    {
        Vector3 world = Camera.transform.localPosition;
        
        Debug.Log($"cam pos {world}");
        
        vRPlaySpace.transform.position = -world + transform.position;
    }

    IEnumerator waiter()
    {
        //Wait for 4 seconds
        yield return new WaitForSeconds(2);
        Debug.Log("Reset Camera");
        Reset();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
