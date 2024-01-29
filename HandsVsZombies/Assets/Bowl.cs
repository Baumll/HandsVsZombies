using System.Collections;
using System.Collections.Generic;
using Microsoft.MixedReality.Toolkit.Input;
using Microsoft.MixedReality.Toolkit.Utilities;
using UnityEngine;

public class Bowl : MonoBehaviour, IMixedRealityPointerHandler
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerDown(MixedRealityPointerEventData eventData)
    {
        Debug.Log("Trigger");
        if (eventData.Handedness == Handedness.Left)
        {
            Debug.Log("Left Hand Baby");
        }
        
        if (eventData.Handedness == Handedness.Right)
        {
            Debug.Log("Right Hand Baby");
        }
    }

    public void OnPointerDragged(MixedRealityPointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    public void OnPointerUp(MixedRealityPointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    public void OnPointerClicked(MixedRealityPointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }
}
