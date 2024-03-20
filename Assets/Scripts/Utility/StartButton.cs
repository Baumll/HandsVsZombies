using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.Input;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using TMPro;

public class NewBehaviourScript : MonoBehaviour, IMixedRealityPointerHandler
{
    //Started das Spiel oder resetet die Scene, wenn man verloren hat.

    public UnityEvent OnResetbutton;
    public UnityEvent OnStartbutton;

    private MeshRenderer meshRenderer;
    private BoxCollider boxCollider;
    private TextMeshPro textMeshPro;

    public GameObject exitButton;

    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        boxCollider = GetComponent<BoxCollider>();
        textMeshPro = GetComponentInChildren<TextMeshPro>();
    }

    private void Update()
    {
        if (GameManager.instance.gameIsLost)
        {
            meshRenderer.enabled = true;
            boxCollider.enabled = true;
            textMeshPro.enabled = true;
            textMeshPro.text = "Reset";
            exitButton.SetActive(true);
        }
        else
        {
            if(textMeshPro.enabled)
            {
                textMeshPro.text = "Start";
            }
        }
    }

    public void OnPointerDown(MixedRealityPointerEventData eventData)
    {
       
        GameManager.instance.StartGame();
        meshRenderer.enabled = false;
        boxCollider.enabled = false;
        textMeshPro.enabled = false;
        exitButton.SetActive(false);
        if (GameManager.instance.gameIsLost)
        {
            OnResetbutton.Invoke();
        }
        else
        {
            OnStartbutton.Invoke();
        }
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
