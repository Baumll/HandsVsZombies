using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShredderAudio : MonoBehaviour
{

    private SchredderScript schredderScript;
    void Start()
    {
        schredderScript = GetComponentInParent<SchredderScript>();
        if (schredderScript == null)
        {
            Debug.LogError("SchredderScript component not found in the parent objects.");
        }
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (schredderScript.isSchreddering == true)
        {
            
            
        }
            
    }
}
