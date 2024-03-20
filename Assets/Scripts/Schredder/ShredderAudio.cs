using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShredderAudio : MonoBehaviour
{

    private SchredderScript schredderScript;

    [SerializeField] private AudioSource schredderSound;
    void Start()
    {
        schredderScript = GetComponentInParent<SchredderScript>();
        if (schredderScript == null)
        {
            Debug.LogError("SchredderScript component not found in the parent objects.");
        }
    }


    private void Update()
    {
        //Spielt Schreddergeräusch ab wenn Zombie geschreddert wird
        if (!schredderSound.isPlaying && schredderScript.isSchreddering == true)
        {
            schredderSound.Play();
        }
    }
    
    
}
