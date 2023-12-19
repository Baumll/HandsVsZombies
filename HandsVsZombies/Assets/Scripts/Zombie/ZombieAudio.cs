using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ZombieAudio : MonoBehaviour
{
    private int lastInt = 0;
    private float randomDelay = 10;

    private AudioSource activeAudioSource;
    private bool isRunning = true;
    
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
        StartCoroutine(ZombieSounds());
    }

    // Update is called once per frame
    void Update()
    {
        SoundSelection();
        randomDelay = Random.Range(5, 10);

    }

    private void SoundSelection()
    {
        int randomIntSound = Random.Range(0, 100);

        if (randomIntSound < 3)
            activeAudioSource = minecraftSource;
        
        if (randomIntSound >= 3 && randomIntSound <= 10)
            activeAudioSource = minecraftSource;
        
        if (randomIntSound >10 || randomIntSound <= 20)
            activeAudioSource = source1;
        
        if (randomIntSound >20 || randomIntSound <= 30)
            activeAudioSource = source2;
        
        if (randomIntSound >30 || randomIntSound <= 40)
            activeAudioSource = source3;
        
        if (randomIntSound >40 || randomIntSound <= 50)
            activeAudioSource = source4;
        
        if (randomIntSound >50 || randomIntSound <= 60)
            activeAudioSource = source5;
        
        if (randomIntSound >60 || randomIntSound <= 70)
            activeAudioSource = source6;
        
        if (randomIntSound >70 || randomIntSound <= 80)
            activeAudioSource = source7;
        
        if (randomIntSound >80 || randomIntSound <= 90)
            activeAudioSource = source8;
        
        if (randomIntSound >90 || randomIntSound <= 100)
            activeAudioSource = source9;
        
    }

    private void OnDestroy()
    {
        isRunning = false;
    }

    IEnumerator ZombieSounds()
    {
        while (isRunning == true)
        {
            Debug.Log("Coroutine is running");
            yield return new WaitForSeconds(randomDelay);
            activeAudioSource.Play();
        }

    }
}
