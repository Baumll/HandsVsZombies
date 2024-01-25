using System;
using UnityEngine;

public class Screamingscript : MonoBehaviour
{
    public string zombieTag = "Zombie";  // Set the tag for your zombies in the Unity editor
    private GameObject[] zombies;
    [SerializeField] private AudioSource scream;

    private float screamingDistance = 1.5f;
    public float closestDistance;

    void Start()
    {
        // Check if the AudioSource is null, and if so, log a warning
        if (scream == null)
        {
            Debug.LogWarning("AudioSource not assigned to the script.");
        }
    }

    void Update()
    {
        zombies = GameObject.FindGameObjectsWithTag(zombieTag);
        
        if (zombies.Length > 0)
        {
            closestDistance = Mathf.Infinity;
            GameObject closestZombie = null;

            foreach (GameObject zombie in zombies)
            {
                float distance = Vector3.Distance(transform.position, zombie.transform.position);

                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestZombie = zombie;
                }
                
            }
            
            //Debug.Log("Shortest Distance is:" + closestDistance);

            if (scream != null && closestZombie != null && closestDistance <= screamingDistance)
            {
                float t = closestDistance / screamingDistance;
                float screamVolume = Mathf.Lerp(1f, 0f, t);
                scream.volume = screamVolume;

                if (!scream.isPlaying)
                {
                    scream.Play();
                }
            }
            

        }
        else
        {
            Debug.Log("No zombies in the scene.");
        }
        
        //Debug.Log("Zombies in Scene:" + zombies.Length);
    }
}