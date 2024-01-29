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
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("EXPLOSION!!!");
    }

    // Update is called once per frame
    void Update()
    {
        lifeTime -= Time.deltaTime;
        if (lifeTime < 0)
        {
            Destroy(gameObject);
        }
    }

    /*private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Zombie"))
        {
            Debug.Log("Found Zombie");
            ZombieScript zombie = other.transform.root.GetComponent<ZombieScript>();
            if (zombie != null)
            {
                print("[Explosion] Angekommen Trigger");
                zombie.Kill();
                zombie.GetComponentInChildren<Rigidbody>().AddExplosionForce(power, transform.position, radius, upLift );
            }

        }
    }*/
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Zombie"))
        {
            Debug.Log("Zombie Collision " + other.name);
            ZombieScript zombie = other.transform.parent.GetComponent<ZombieScript>();
            if (zombie != null)
            {
                print("[Explosion] Angekommen Trigger " + zombie.name);
                zombie.Kill();
                zombie.GetComponentInChildren<Rigidbody>().AddExplosionForce(power, transform.position, radius, upLift );
            }

        }
    }
    
    private void OnCollisionrEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Zombie"))
        {
            Debug.Log("Found Zombie");
            ZombieScript zombie = collision.transform.root.GetComponent<ZombieScript>();
            if (zombie != null)
            {
                print("[Explosion] Angekommen Normal");
                zombie.Kill();
                zombie.GetComponentInChildren<Rigidbody>().AddExplosionForce(power, transform.position, radius, upLift );
            }

        }
    }
}
