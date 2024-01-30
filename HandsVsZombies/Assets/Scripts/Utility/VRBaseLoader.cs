using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VRBaseLoader : MonoBehaviour
{
    // Start is called before the first frame update

    private void Awake()
    {
        if (! SceneManager.GetSceneByName("VRBase").isLoaded)
        {
            SceneManager.LoadSceneAsync("VRBase", LoadSceneMode.Additive);
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
