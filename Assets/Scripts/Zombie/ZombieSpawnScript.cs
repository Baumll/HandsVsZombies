using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawnScript : MonoBehaviour
{
    [SerializeField] private GameObject zombie;
    [SerializeField] private GameObject target;

    public GameObject SpawnZombie()
    {
        GameObject newZombie = Instantiate(zombie, transform);
        newZombie.transform.position = transform.position;
        newZombie.transform.rotation = transform.rotation;
        newZombie.GetComponent<ZombieController>().MovePositionTransform = target.transform;
        return newZombie;
    }
}
