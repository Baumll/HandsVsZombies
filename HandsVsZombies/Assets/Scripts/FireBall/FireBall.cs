using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    [SerializeField] private GameObject explosion;

    public void OnCollisionEnter(Collision collision)
    {
        GameObject newExposion = Instantiate(explosion,transform.position,transform.rotation);
        Destroy(gameObject);
    }
    
    public void OnTriggerEnter(Collider other)
    {
        GameObject newExposion = Instantiate(explosion,transform.position,transform.rotation);
        Destroy(gameObject);
    }
}
