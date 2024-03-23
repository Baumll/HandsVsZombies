using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class explosionScript : MonoBehaviour
{
    [SerializeField] private float power = 1.0f;

    [SerializeField] private float radius = .2f;

    [SerializeField] private float upLift = .3f;
    
    [SerializeField] private float lifeTime = 1f;

    // Selbstzerstörung
    void Update()
    {
        lifeTime -= Time.deltaTime;
        if (lifeTime < 0)
        {
            Destroy(gameObject);
        }
    }

    //Wenn ein Zombie Getroffen wird fliegt dieser weg und stirbt
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Zombie"))
        {
            Debug.Log("Zombie Collision " + other.name);
            ZombieController zombie = other.transform.parent.GetComponent<ZombieController>();
            if (zombie != null)
            {
                print("[Explosion] Angekommen Trigger " + zombie.name);
                zombie.Kill();
                zombie.GetComponentInChildren<Rigidbody>().AddExplosionForce(power, transform.position, radius, upLift );
            }

        }
    }
}
