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

    [SerializeField] private bool isSchreddering = false;
    [SerializeField] private float schredderTime = 1f;
    [SerializeField] private float deltaSchredderTime = 0f;

    // Start is called before the first frame update
    void Start()
    {
        schreddeerZone.OnSchredder.AddListener(enableSchreddering);
    }

    // Update is called once per frame
    void Update()
    {
        if (isSchreddering)
        {
            addBloodLevel(.5f*Time.deltaTime);
            deltaSchredderTime += Time.deltaTime;
            if (deltaSchredderTime >= schredderTime)
            {
                disableSchreddering();
                deltaSchredderTime = 0f;
            }
        }
        else
        {
            addBloodLevel(-.05f*Time.deltaTime);
        }
    }

    public void enableSchreddering()
    {
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
            bloody.material.SetFloat("_Blodymess", level);
        }

    }

    //Gibt den aktuellen blut stand wieder zurrück
    public float addBloodLevel(float amount)
    {
        foreach (var bloody in bloodyObjectList)
        {
            bloody.material.SetFloat("_Blodymess", getBloodLevel() + amount);
        }
        return getBloodLevel() + amount;
    }

    public float getBloodLevel()
    {
        if (bloodyObjectList.Length > 0)
        {
            return bloodyObjectList[0].material.GetFloat("_Blodymess");
        }
        return -1;
    }

}
