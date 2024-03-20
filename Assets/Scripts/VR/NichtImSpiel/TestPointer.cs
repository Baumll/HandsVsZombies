using Microsoft.MixedReality.Toolkit.Input;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TestPointer : MonoBehaviour, IMixedRealityPointerHandler, IMixedRealityFocusHandler
{
    //Wird nicht verwendet ist aber eine gute Referenz

    [SerializeField] private MeshRenderer m_Renderer;
    [SerializeField] private Color m_Color;
    private Color def_Color;
    private Material m_material;

    public void OnPointerClicked(MixedRealityPointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    public void OnPointerDown(MixedRealityPointerEventData eventData)
    {
        IMixedRealityPointer ptr = eventData.Pointer;
        
        //Debug.Log(message$"Pointer Name: {ptr.PointerName}");
        m_material.color = m_Color;
    }

    public void OnPointerDragged(MixedRealityPointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    public void OnPointerUp(MixedRealityPointerEventData eventData)
    {
        m_material.color = def_Color;
    }

    // Start is called before the first frame update
    void Start()
    {
        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
        m_material = meshRenderer.material;
        def_Color = m_material.color;

    }

    public void OnFocusEnter(FocusEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    public void OnFocusExit(FocusEventData eventData)
    {
        throw new System.NotImplementedException();
    }
}
