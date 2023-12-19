using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DestroyAfterStart : MonoBehaviour
{
    [SerializeField] private float time = 10;
    private float deltaTime = 0;
    private bool isActive = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.gameIsActive)
        {
            deltaTime += Time.deltaTime;
        }

        if (deltaTime > Time.deltaTime && isActive)
        {
            TextMeshPro[] textMeshList = GetComponentsInChildren<TextMeshPro>();

            for(int i = 0; i < textMeshList.Length; i ++)
            {
                textMeshList[i].enabled = false;
            }
            isActive = false;
        }   
    }

    public void SetActive()
    {
        isActive = true;
        deltaTime = 0;
    }
}
