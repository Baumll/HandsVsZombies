using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Verwaltet das Spielgeschehen, Wellen, Score, Pausen... 

    public static GameManager instance { get; private set; }

    [SerializeField] private WaveScriptableObject[] waveList;
    private WaveScriptableObject activeWave;
    private int wave = 0;
    private int zombiesSpawntThisWave = 0;
    private float deltaWaveTime = 0;
    public bool gameIsActive = false;
    public bool gameIsLost = false;
    private bool isPause = true;
    public bool leftCanShoot = false;
    public bool rightCanShoot = false;
    private GameObject[] spawnerList;
    [SerializeField] private float score;

    // Start is called before the first frame update
    void Awake()
    {
        //Ensure there is only one instance
        if (instance != null && instance != this) 
        { 
            Destroy(this); 
        } 
        else 
        { 
            instance = this; 
        } 
    }
    
    void Start()
    {
        //Gives all Zombie Spawner
        spawnerList = GameObject.FindGameObjectsWithTag("Spawner");
        Debug.Log("List Size: " + spawnerList.Length.ToString());
    }

    //Wellen System
    void Update()
    {
        if (gameIsActive)
        {
            if (wave < waveList.Length)
            {
                activeWave = waveList[wave];
            }
            else
            {
                activeWave = waveList[waveList.Length - 1];
            }
            deltaWaveTime += Time.deltaTime;
            
            //Wave starts with break
            if (isPause)
            {
                if (deltaWaveTime >= activeWave.PauseLenght)
                {
                    deltaWaveTime = 0;
                    isPause = !isPause;
                    zombiesSpawntThisWave = 0;
                }
            }
            else
            {
                if (deltaWaveTime >= activeWave.WaveLenght)
                {
                    deltaWaveTime = 0;
                    isPause = !isPause;
                    wave += 1;
                }
                else
                {
                    if (activeWave.ZombieCount - zombiesSpawntThisWave > 0)
                    {
                        float secondPerZombie = activeWave.ZombieCount / activeWave.WaveLenght;
                        if (Mathf.Floor(secondPerZombie * deltaWaveTime) > zombiesSpawntThisWave)
                        {
                            //Spawn Zombie
                            GameObject spawner = spawnerList[Random.Range(0, spawnerList.Length)];
                            spawner.GetComponent<ZombieSpawnScript>().SpawnZombie();
                            zombiesSpawntThisWave += 1;
                        }
                    }
                }
            }
        }
    }

    public void StartGame()
    {
        gameIsActive = true;
    }

    public void PauseGame()
    {
        gameIsActive = false;
    }

    //You lose the Game
    public void GameLost()
    {
        PauseGame();
        gameIsLost = true;
    }

    public void AddScore(float amount)
    {
        score += amount;
    }

    public void SetScore(float newScore)
    {
        score += newScore;
    }

    public float GetScore()
    {
        return score;
    }
}
