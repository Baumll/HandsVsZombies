using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ZombieAudio : MonoBehaviour
{
    private int lastInt = 0;
    private int randomDelay = 10;
    private int randomIntSound;

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
        randomDelay = Random.Range(10, 20);

    }

    private void SoundSelection()
    {
        randomIntSound = Random.Range(0, 100);

        if (randomIntSound <= 1)
            activeAudioSource = minecraftSource;
        else if (randomIntSound <= 12)
            activeAudioSource = source1;
        else if (randomIntSound <= 23)
            activeAudioSource = source2;
        else if (randomIntSound <= 34)
            activeAudioSource = source3;
        else if (randomIntSound <= 45)
            activeAudioSource = source4;
        else if (randomIntSound <= 56)
            activeAudioSource = source5;
        else if (randomIntSound <= 67)
            activeAudioSource = source6;
        else if (randomIntSound <= 78)
            activeAudioSource = source7;
        else if (randomIntSound <= 89)
            activeAudioSource = source8;
        else if (randomIntSound <= 100)
            activeAudioSource = source9;
    }


    private void OnDestroy()
    {
        isRunning = false;
    }
    

    IEnumerator ZombieSounds()
    {
        while (isRunning)
        {
            SoundSelection();

            if (!activeAudioSource.isPlaying)
            {
                activeAudioSource.Play();
                yield return new WaitForSeconds(randomDelay);
            }
            else
            {
                yield return null;
            }
        }
    }

}