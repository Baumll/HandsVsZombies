using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawnScript : MonoBehaviour
{
    [SerializeField] private GameObject zombie;
    [SerializeField] private GameObject target;

    public GameObject SpawnZobie()
    {
        GameObject newZombie = Instantiate(zombie, transform);
        newZombie.transform.position = transform.position;
        newZombie.transform.rotation = transform.rotation;
        newZombie.GetComponent<ZombieScript>().MovePositionTransform = target.transform;
        return newZombie;
    }
}
