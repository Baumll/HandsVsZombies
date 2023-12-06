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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Zombie"))
        {
        RenderRefernce reference = other.GetComponent<RenderRefernce>();
            if(reference != null)
            {
                /*foreach (var renderer in reference.Renderer)
                {
                    renderer.gameObject.SetActive(false);
                }*/
                other.transform.root.gameObject.SetActive(false);
                OnSchredder.Invoke();
            }
        }
    }

    public void OnTouchStarted(HandTrackingInputEventData eventData)
    {
        Debug.Log("Enter Hand in Schredder");
        OnSchredder.Invoke();
    }

    public void OnTouchCompleted(HandTrackingInputEventData eventData)
    {
        OffSchredder.Invoke();
    }

    public void OnTouchUpdated(HandTrackingInputEventData eventData)
    {
        Debug.Log("Enter Hand in Schredder");
    }

    public void OnPointerDown(MixedRealityPointerEventData eventData)
    {
        Debug.Log("On Pointer Down");
    }

    public void OnPointerDragged(MixedRealityPointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    public void OnPointerUp(MixedRealityPointerEventData eventData)
    {
        Debug.Log("On Pointer Up");
    }

    public void OnPointerClicked(MixedRealityPointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }
}
