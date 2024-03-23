using System.Collections;
using System.Collections.Generic;
using Microsoft.MixedReality.Toolkit.Input;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
[RequireComponent(typeof(NearInteractionTouchable), typeof(Collider))]
public class SchredderZoneScript : MonoBehaviour, IMixedRealityPointerHandler
{

    public UnityEvent OnSchredder;
    public UnityEvent OffSchredder;
    

    //Schreddert Zombies und Anderes
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Shredderable"))
        {
            Destroy(other.gameObject);
            OnSchredder.Invoke();
        }
        if (other.gameObject.CompareTag("Zombie"))
        {
            Destroy(other.GetComponentInParent<ZombieController>().gameObject);
            GameManager.Instance.AddScore(1);
            OnSchredder.Invoke();
        }
    }

    //Schreddert auch die Hand
    public void OnPointerDown(MixedRealityPointerEventData eventData)
    {
        OnSchredder.Invoke();
    }

    public void OnPointerDragged(MixedRealityPointerEventData eventData)
    {
        //throw new System.NotImplementedException();
    }

    public void OnPointerUp(MixedRealityPointerEventData eventData)
    {
        OffSchredder.Invoke();
    }

    public void OnPointerClicked(MixedRealityPointerEventData eventData)
    {
        //throw new System.NotImplementedException();
    }
}
