using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    [SerializeField] private GameObject explosion;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter(Collision collision)
    {
        GameObject newExposion = Instantiate(explosion);
        Destroy(gameObject);
    }
    
    public void OnTriggerEnter(Collider other)
    {
        GameObject newExposion = Instantiate(explosion);
        Destroy(gameObject);
    }
}