using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline.Actions;
using UnityEngine;
using UnityEngine.Events;

public class SchredderZoneScript : MonoBehaviour
{

    public UnityEvent OnSchredder;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Zombie"))
        {
            Debug.Log("Nom Nom Nom");
            Destroy(other.gameObject);
            OnSchredder.Invoke();
        }
    }
}
