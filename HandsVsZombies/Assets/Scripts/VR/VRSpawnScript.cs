using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.MixedReality.Toolkit.Utilities;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VRSpawnScript : MonoBehaviour
{
    public GameObject vRPlaySpace;
    public GameObject Camera;

    [SerializeField] SceneTransition sceneTransition;

    public bool reset;

    public void OnValidate()
    {
        reset = false;
        ResetCamera();
    }

    // Start is called before the first frame update
    private void Start()
    {
        StartCoroutine(waiter());
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
        sceneTransition.CloseTransition();
        //Lade Neue Scene
        SceneManager.UnloadSceneAsync("GameScene");
        SceneManager.LoadSceneAsync("GameScene", LoadSceneMode.Additive);
    }

    public void StartTransitionOpen()
    {

    }

}
