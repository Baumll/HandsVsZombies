using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{

    private Material material;
    [SerializeField] private float transitionTime = 1.0f;
    private float deltaTransitionTime = 0;
    public bool open = true;
    private float maxRange = 1.2f;
    [SerializeField] private Scene sceneTowatch;

    private void Start()
    {
        material = GetComponent<Material>();
    }

    private void Update()
    {
        if (deltaTransitionTime > 0)
        {
            deltaTransitionTime -= Time.deltaTime;
        }

        if (open)
        {
            material.SetFloat("_Radius", (1-deltaTransitionTime/transitionTime) * maxRange);
        }
        else
        {
            material.SetFloat("_Radius", (deltaTransitionTime / transitionTime) * maxRange);
            if(sceneTowatch != null)
            {
                if (sceneTowatch.isLoaded)
                {
                    open = true;
                }
            }
        }       
    }

    public void OpenTransition()
    {
        deltaTransitionTime = transitionTime;
        open = true;
    }

    public void CloseTransition() 
    {
        deltaTransitionTime = transitionTime;
        open = false;
    }
}
