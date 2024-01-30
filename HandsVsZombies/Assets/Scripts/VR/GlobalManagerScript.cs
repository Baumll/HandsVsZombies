using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.MixedReality.Toolkit.Input;
using Microsoft.MixedReality.Toolkit.Utilities;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GlobalManager : MonoBehaviour
{
    public static GlobalManager instance { get; private set; }

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

    void Awake()
    {

        #if UNITY_EDITOR

        #else
                SceneManager.LoadSceneAsync("GameScene", LoadSceneMode.Additive);
        #endif
        //Ensure there is only one instance
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    private void Start()
    {
        //Warted damit die Scene fertig geladen ist
        StartCoroutine(waiter());
        material = sceneTransition.GetComponent<Renderer>().material;
        
        //Deaktiviere Teleport
        ShellHandRayPointer [] shellHandRayPointers = GameObject.FindObjectsByType<ShellHandRayPointer>(FindObjectsInactive.Include,FindObjectsSortMode.None);
        foreach (ShellHandRayPointer shellHandRayPointer in shellHandRayPointers)
        {
            shellHandRayPointer.gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        if (deltaTransitionTime > 0)
        {
            deltaTransitionTime -= Time.deltaTime;
        }

        if (open)
        {
            //÷ffnet sich langsam
            material.SetFloat("_Radius", (deltaTransitionTime/transitionTime) * maxRange);
        }
        else
        {
            //Schlieﬂt sich langsam
            material.SetFloat("_Radius", (1 - deltaTransitionTime / transitionTime ) * maxRange);
            //If Lens is Closed restart Game
            if (deltaTransitionTime <= 0)
            {
                SceneManager.UnloadScene("GameScene");
                SceneManager.LoadSceneAsync("GameScene", LoadSceneMode.Additive);
                OpenTransition();
            }
        }

        //Y Knopf
        if (Input.GetButtonDown("Jump"))
        {
            ResetCamera();
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
        //Wait for 2 seconds
        yield return new WaitForSeconds(2);
        Debug.Log("Reset Camera");
        ResetCamera();
    }


    public void ResetGameScene()
    {
        print("[VR Spawn Point] Reset Scene");
        CloseTransition();
    }

    public void ExitGame()
    {
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #else
                    Application.Quit();
        #endif
    }
}
