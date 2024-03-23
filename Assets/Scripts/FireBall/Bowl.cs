using System.Collections;
using System.Collections.Generic;
using Microsoft.MixedReality.Toolkit.Input;
using Microsoft.MixedReality.Toolkit.Utilities;
using UnityEngine;

public class Bowl : MonoBehaviour, IMixedRealityPointerHandler
{

    //Aktiviert die Hand für den Feuerball
    public void OnPointerDown(MixedRealityPointerEventData eventData)
    {
        if (eventData.Handedness == Handedness.Left)
        {
            GameManager.Instance.leftCanShoot = true;   
        }
        
        if (eventData.Handedness == Handedness.Right)
        {
            GameManager.Instance.rightCanShoot = true;
        }
    }

    public void OnPointerDragged(MixedRealityPointerEventData eventData)
    {
        //throw new System.NotImplementedException();
    }

    public void OnPointerUp(MixedRealityPointerEventData eventData)
    {
        //throw new System.NotImplementedException();
    }

    public void OnPointerClicked(MixedRealityPointerEventData eventData)
    {
        //throw new System.NotImplementedException();
    }
}
