using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAudio : MonoBehaviour
{
    private int lastInt = 0;

    private AudioSource activeAudioSource;
    
    [SerializeField] private AudioSource source1;
    [SerializeField] private AudioSource source2;
    [SerializeField] private AudioSource source3;
    [SerializeField] private AudioSource source4;
    [SerializeField] private AudioSource source5;
    [SerializeField] private AudioSource source6;
    [SerializeField] private AudioSource source7;
    [SerializeField] private AudioSource source8;
    [SerializeField] private AudioSource source9;
    [SerializeField] private AudioSource minecraftSource;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    private void SoundSelection()
    {
        int randomInt = Random.Range(0, 100);

        if (randomInt < 3)
            activeAudioSource = minecraftSource;
        
        if (randomInt >= 3 && randomInt <= 10)
            activeAudioSource = minecraftSource;
        
        if (randomInt >10 || randomInt <= 20)
            activeAudioSource = source1;
        
        if (randomInt >20 || randomInt <= 30)
            activeAudioSource = source2;
        
        if (randomInt >30 || randomInt <= 40)
            activeAudioSource = source3;
        
        if (randomInt >40 || randomInt <= 50)
            activeAudioSource = source4;
        
        if (randomInt >50 || randomInt <= 60)
            activeAudioSource = source5;
        
        if (randomInt >60 || randomInt <= 70)
            activeAudioSource = source6;
        
        if (randomInt >70 || randomInt <= 80)
            activeAudioSource = source7;
        
        if (randomInt >80 || randomInt <= 90)
            activeAudioSource = source8;
        
        if (randomInt >90 || randomInt <= 100)
            activeAudioSource = source9;
        
    }
}
