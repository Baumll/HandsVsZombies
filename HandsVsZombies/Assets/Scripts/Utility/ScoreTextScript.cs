using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreTextScript : MonoBehaviour
{
    private string startText;

    // Start is called before the first frame update
    void Start()
    {
        TextMeshPro textMeshPro = GetComponentInChildren<TextMeshPro>();
        startText = textMeshPro.text;
        textMeshPro.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.gameIsLost)
        {
            TextMeshPro textMeshPro = GetComponentInChildren<TextMeshPro>();
            textMeshPro.text = startText + GameManager.instance.GetScore();
        }
    }
}
