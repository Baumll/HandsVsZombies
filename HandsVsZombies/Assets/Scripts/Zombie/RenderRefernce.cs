using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderRefernce : MonoBehaviour
{
    [SerializeField] private Renderer[] renderer;
    [SerializeField] private GameObject[] replacementList;

    public Renderer[] Renderer => renderer;
    public GameObject[] ReplacementList => replacementList;
}
