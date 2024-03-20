using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SchredderScript : MonoBehaviour
{

    //Die Liste von Objeten die blutiger werden sollen.
    [SerializeField] private MeshRenderer[] bloodyObjectList;
    [SerializeField] private ParticleSystem[] bloodParticelSystem;
    [SerializeField] private SchredderZoneScript schreddeerZone;

    public bool isSchreddering = false;
    [SerializeField] private float schredderTime = 1f;
    private float deltaSchredderTime = 0f;

    // Start is called before the first frame update
    void Start()
    {
        schreddeerZone.OnSchredder.AddListener(enableSchreddering);
    }

    // Fügt Blut hinzu/macht es weg
    void Update()
    {
        if (isSchreddering)
        {
            addBloodLevel(2f*Time.deltaTime);
            deltaSchredderTime += Time.deltaTime;
            if (deltaSchredderTime >= schredderTime)
            {
                disableSchreddering();
                deltaSchredderTime = 0f;
            }
        }
        else
        {
            addBloodLevel(-.2f*Time.deltaTime);
        }
    }

    public void enableSchreddering()
    {
        Debug.Log("Schredder An");
        isSchreddering=true;
        foreach (var particleSystem in bloodParticelSystem)
        {
            particleSystem.Play();
        }
    }
    
    public void disableSchreddering()
    {
        isSchreddering=false;
        foreach (var particleSystem in bloodParticelSystem)
        {
            particleSystem.Stop();
        }
    }
    public void setBloodLevel(float level){
        foreach(var bloody in bloodyObjectList)
        {
            bloody.GetComponent<MeshRenderer>().material.SetFloat("_Blodymess", level);
        }

    }

    //Gibt den aktuellen blut stand wieder zurrück
    public float addBloodLevel(float amount)
    {
        foreach (var bloody in bloodyObjectList)
        {
            bloody.GetComponent<MeshRenderer>().material.SetFloat("_Blodymess", getBloodLevel() + amount);
        }
        return getBloodLevel() + amount;
    }

    public float getBloodLevel()
    {
        if (bloodyObjectList.Length > 0)
        {
            return bloodyObjectList[0].GetComponent<MeshRenderer>().material.GetFloat("_Blodymess");
        }
        return -1;
    }

}
