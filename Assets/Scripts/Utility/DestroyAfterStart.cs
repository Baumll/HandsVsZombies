using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DestroyAfterStart : MonoBehaviour
{
    //Das Srpt Zerstört nur die Textinfos nach einer gewissen Zeit

    [SerializeField] private float time = 10;
    private float deltaTime = 0;
    private bool isActive = false;
    private TextMeshPro textMeshPro;

    // Start is called before the first frame update
    void Start()
    {
        textMeshPro = GetComponentInChildren<TextMeshPro>();
        textMeshPro.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (deltaTime > time)
        {
            if (isActive)
            {
                TextMeshPro[] textMeshList = GetComponentsInChildren<TextMeshPro>();

                for(int i = 0; i < textMeshList.Length; i ++)
                {
                    textMeshList[i].enabled = false;
                }
                isActive = false;
            }
            return;
        }
        
        if (GameManager.instance.gameIsActive)
        {
            textMeshPro.enabled = true;
            if (!isActive)
            {
                isActive = true;
                deltaTime = 0;
            }
            deltaTime += Time.deltaTime;
        }

 
    }

    public void SetActive()
    {
        isActive = true;
        deltaTime = 0;
    }
}
