using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderRefernce : MonoBehaviour
{
    [SerializeField] private SkinnedMeshRenderer[] renderer;

    public SkinnedMeshRenderer[] Renderer => renderer;
}
