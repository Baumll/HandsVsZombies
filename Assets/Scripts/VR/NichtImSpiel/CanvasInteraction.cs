using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasInteraction : MonoBehaviour
{
    //Wird nicht Verwendet ist aber eine gute Referenz
public void OnButtonQuit()
{
    #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
    #else
            Application.Quit();
    #endif
}

public void OnButtonStart()
{
        AsyncOperation aop = SceneManager.UnloadSceneAsync(1);

        aop.completed += (a) =>
        {
            SceneManager.LoadScene(2, LoadSceneMode.Additive);
        };

        Debug.Log("Starrrrt");
        Debug.Log("I am a pirate!");
        Debug.Log("Arrr!!");
    }
}
