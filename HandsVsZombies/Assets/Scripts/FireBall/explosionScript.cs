using System;
using System.Collections;
using System.Collections.Generic;
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
        Debug.Log("EXPLOSION!!!");
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Zombie"))
        {
            ZombieScript zombie = other.transform.root.GetComponent<ZombieScript>();
            if (zombie != null)
            {
                zombie.EnableRagdoll();
                zombie.GetComponentInChildren<Rigidbody>().AddExplosionForce(power, transform.position, radius, upLift );
            }

        }
    }
}
