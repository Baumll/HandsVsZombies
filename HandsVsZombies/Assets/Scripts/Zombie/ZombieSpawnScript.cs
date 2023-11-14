using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawnScript : MonoBehaviour
{
    [SerializeField] private GameObject zombie;
    [SerializeField] private GameObject target;

    [Tooltip("Time between zombie spawn in sec. ")]
    [Range(0, 100)]
    [SerializeField] private float spawnTime;
    //private float deltaSpawnTime = 0;

    public GameObject zombie1 { get => zombie; set => zombie = value; }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (deltaSpawnTime <= 0)
        //{
        //    deltaSpawnTime = spawnTime;
        //    SpawnZobie();
        //}
        //else
        //{
        //    deltaSpawnTime -= Time.deltaTime;
        //}
    }

    public GameObject SpawnZobie()
    {
        GameObject newZombie = Instantiate(zombie);
        newZombie.transform.position = transform.position;
        newZombie.transform.rotation = transform.rotation;
        newZombie.GetComponent<ZombieScript>().MovePositionTransform = target.transform;
        return newZombie;
    }
}
