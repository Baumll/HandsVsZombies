using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SchredderScript : MonoBehaviour
{

    //Die Liste von Objeten die blutiger werden sollen.
    [SerializeField] private MeshRenderer[] bloodyObjectList;
    [SerializeField] private ParticleSystem bloodParticelSystem;
    [SerializeField] private SchredderZoneScript schreddeerZone;

    [SerializeField] private bool isSchreddering = false;

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
            addBloodLevel(0.1f*Time.deltaTime);
            if (bloodParticelSystem)
            {
                bloodParticelSystem.Play();
            }
        }
        else
        {
            bloodParticelSystem.Stop();
        }
    }

    public void enableSchreddering()
    {
        isSchreddering=true;
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
