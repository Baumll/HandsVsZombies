using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ZombieWaveHandler : MonoBehaviour
{

    [SerializeField] private float zombiesPerWave = 5f;

    [Tooltip("The next Wave is X times more Zombies ")]
    [SerializeField] private float zombiesPerWaveScaling = 1.5f;

    [SerializeField] private float waveLenght = 10f;
    [SerializeField] private float waveLenghtScaling = 1.25f;
    [SerializeField] private float timeBetweenWaves = 10f;
    [SerializeField] private float timeBetweenWavesScaling = 1.1f;
    private int wave = 0;
    private int zombiesSpawntThisWave = 0;
    private float waveTime = 0;
    private bool isPause = false;
    private GameObject[] spawnerList;

    // Start is called before the first frame update
    void Start()
    {
        //Gives all Zombie Spawner
        spawnerList = GameObject.FindGameObjectsWithTag("Spawner");
        Debug.Log("List Size: " + spawnerList.Length.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        waveTime += Time.deltaTime;
        if (isPause)
        {
            if (waveTime >= waveLenght * waveLenghtScaling * wave)
            {
                wave += 1;
                waveTime = 0;
                isPause = !isPause;
            }
        }
        else
        {
            if (waveTime >= timeBetweenWaves * timeBetweenWavesScaling * wave)
            {
                waveTime = 0;
                isPause = !isPause;
            }
        }

        if (isPause)
        {
            if(zombiesPerWave - zombiesSpawntThisWave > 0)
            {
                float secondPerZombie = (waveLenght * waveLenghtScaling * wave ) / (zombiesPerWave * zombiesPerWaveScaling * wave);
                if (Mathf.Floor(secondPerZombie * waveTime) > zombiesSpawntThisWave)
                {
                    //Spawn Zombie
                    GameObject spawner = spawnerList[Random.Range(0, spawnerList.Length - 1)];
                    spawner.GetComponent<ZombieSpawnScript>().SpawnZobie();
                    zombiesSpawntThisWave += 1;
                }
            }
        }
    }
}
