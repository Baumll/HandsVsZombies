using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.Input;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour, IMixedRealityPointerHandler
{
    [SerializeField] private Scene gameScene;

    public UnityEvent OnStartbutton;
    
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
        OnStartbutton.Invoke();
        gameObject.SetActive(false);
    }

    public void OnPointerDragged(MixedRealityPointerEventData eventData)
    {
        //throw new System.NotImplementedException();
    }

    public void OnPointerUp(MixedRealityPointerEventData eventData)
    {
        //Lade Neue Scene
        //OnStartbutton.Invoke();
    }

    public void OnPointerClicked(MixedRealityPointerEventData eventData)
    {
        //throw new System.NotImplementedException();
    }
}
