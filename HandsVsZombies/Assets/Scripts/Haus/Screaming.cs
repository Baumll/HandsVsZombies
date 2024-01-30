using UnityEngine;
using System.Collections;
using UnityEngine.Serialization;

public class Screaming : MonoBehaviour
{
    public string zombieTag = "Zombie";
    [HideInInspector] public GameObject[] zombies;
    private AudioSource activeScream;

    private float screamingDistance = 1.5f;
    public float closestDistance;

    [SerializeField] private AudioSource source1;
    [SerializeField] private AudioSource source2;
    [SerializeField] private AudioSource source3;
    [SerializeField] private AudioSource source4;
    [SerializeField] private AudioSource source5;
    [SerializeField] private AudioSource source6;
    [SerializeField] private AudioSource source7;
    [SerializeField] private AudioSource source8;
    [SerializeField] private AudioSource source9;
    [SerializeField] private AudioSource source10;
    
    private int randomIntSound;
    private bool screamDelayIsActive = false;
    void Start()
    {
        SoundSelection();
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
                ZombieScript zombieScript = zombie.GetComponent<ZombieScript>();
                if (zombieScript != null && zombieScript.alive)
                {
                    float distance = Vector3.Distance(transform.position, zombie.transform.position);

                    if (distance < closestDistance)
                    {
                        closestDistance = distance;
                        closestZombie = zombie;
                    }
                }
            }

            if (activeScream != null && closestZombie != null && closestDistance <= screamingDistance)
            {
                float t = closestDistance / screamingDistance;
                float screamVolume = Mathf.Lerp(0.8f, 0f, t);
                activeScream.volume = screamVolume;
            }

            if (screamDelayIsActive == false && activeScream.isPlaying == false)
            {
                StartCoroutine(ScreamDelay());
                screamDelayIsActive = true;
            }
            
        }
        else
        {
            Debug.Log("No zombies in the scene.");
            closestDistance = Mathf.Infinity;
        }
    }
    
    private IEnumerator ScreamDelay()
    {
        yield return new WaitForSeconds(0.5f);
        SoundSelection();
        
        screamDelayIsActive = false;
        
        if (closestDistance <= screamingDistance)
        {
            activeScream.Play();
            
        }
    }
    
    private void SoundSelection()
    {
        randomIntSound = Random.Range(0, 100);
        
        if (randomIntSound <= 10)
            activeScream = source1;
        else if (randomIntSound <= 20)
            activeScream = source2;
        else if (randomIntSound <= 30)
            activeScream = source3;
        else if (randomIntSound <= 40)
            activeScream = source4;
        else if (randomIntSound <= 50)
            activeScream = source5;
        else if (randomIntSound <= 60)
            activeScream = source6;
        else if (randomIntSound <= 70)
            activeScream = source7;
        else if (randomIntSound <= 80)
            activeScream = source8;
        else if (randomIntSound <= 90)
            activeScream = source9;
        else if (randomIntSound <= 100)
            activeScream = source10;
    }
}