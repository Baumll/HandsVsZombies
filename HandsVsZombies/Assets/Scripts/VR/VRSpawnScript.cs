using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.MixedReality.Toolkit.Utilities;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class VRSpawnScript : MonoBehaviour
{
    public GameObject vRPlaySpace;
    public GameObject Camera;

    [SerializeField] GameObject sceneTransition;

    //For resetting the Camera
    public bool reset;
    
    [SerializeField] private float transitionTime = 1.0f;
    private float deltaTransitionTime = 0;
    public bool open = true;
    private Material material;
    private float maxRange = 1.2f;

    public void OnValidate()
    {
        reset = false;
        ResetCamera();
    }

    // Start is called before the first frame update
    private void Start()
    {
        material = sceneTransition.GetComponent<Renderer>(). material;
    }

    private void Update()
    {
        if (deltaTransitionTime > 0)
        {
            deltaTransitionTime -= Time.deltaTime;
        }

        if (open)
        {
            material.SetFloat("_Radius", (deltaTransitionTime/transitionTime) * maxRange);
        }
        else
        {
            material.SetFloat("_Radius", (1 - deltaTransitionTime / transitionTime ) * maxRange);
            if (deltaTransitionTime < 0)
            {
                SceneManager.UnloadScene("GameScene");
                SceneManager.LoadSceneAsync("GameScene", LoadSceneMode.Additive);
                OpenTransition();
            }
        }

        if (Input.GetButtonDown("Jump"))
        {
            ResetGameScene();
        }

    }
    
    public void OpenTransition()
    {
        deltaTransitionTime = transitionTime;
        open = true;
    }

    public void CloseTransition() 
    {
        Debug.Log("[Transition Plane] Close");
        deltaTransitionTime = transitionTime;
        open = false;
    }
    
    private void ResetCamera()
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
        ResetCamera();
    }

    public void ResetGameScene()
    {
        print("[VR Spawn Point] Reset Scene");
        CloseTransition();
        //Lade Neue Scene
    }

}
