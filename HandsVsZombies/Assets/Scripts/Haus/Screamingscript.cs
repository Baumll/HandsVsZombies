using UnityEngine;

public class ScreamingScript : MonoBehaviour
{
    public string zombieTag = "Zombie";
    private GameObject[] zombies;
    [SerializeField] private AudioSource scream;

    private float screamingDistance = 1.5f;
    public float closestDistance;

    private AudioSource audioSource1;
    private AudioSource audioSource2;
    private AudioClip loopClip; // Dynamic loopClip assignment
    public float crossfadeDuration = 2.0f;

    void Start()
    {
        if (scream == null)
        {
            Debug.LogWarning("AudioSource not assigned to the script.");
        }
        
        InitializeAudioLoop();
    }

    void InitializeAudioLoop()
    {
        audioSource1 = gameObject.AddComponent<AudioSource>();
        audioSource2 = gameObject.AddComponent<AudioSource>();
        
        loopClip = scream.clip;

        audioSource1.clip = loopClip;
        audioSource2.clip = loopClip;
        
        scream.loop = true;

        audioSource1.Play();
        audioSource2.PlayDelayed(crossfadeDuration);
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
            
            AdjustAudioLoopVolume(scream.volume);
        }
        else
        {
            Debug.Log("No zombies in the scene.");
        }
    }

    void AdjustAudioLoopVolume(float volume)
    {
        audioSource1.volume = volume;
        audioSource2.volume = 1.0f - volume;

        if (audioSource1.time >= audioSource1.clip.length - crossfadeDuration)
        {
            // Swap audio sources to ensure seamless looping
            AudioSource temp = audioSource1;
            audioSource1 = audioSource2;
            audioSource2 = temp;

            audioSource2.time = 0;
            audioSource2.PlayDelayed(crossfadeDuration);
        }
    }
}
