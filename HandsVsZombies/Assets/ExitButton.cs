using Microsoft.MixedReality.Toolkit.Input;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ExitButton : MonoBehaviour, IMixedRealityPointerHandler
{
    public UnityEvent OnExitbutton;

    public void OnPointerClicked(MixedRealityPointerEventData eventData)
    {
        OnExitbutton.Invoke();
    }

    public void OnPointerDown(MixedRealityPointerEventData eventData)
    {
        //throw new System.NotImplementedException();
    }

    public void OnPointerDragged(MixedRealityPointerEventData eventData)
    {
        //throw new System.NotImplementedException();
    }

    public void OnPointerUp(MixedRealityPointerEventData eventData)
    {
        //throw new System.NotImplementedException();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance != null)
        {
            if (GameManager.instance.StartGame)
            {
                Destroy(this);
            }
        }
    }
}
