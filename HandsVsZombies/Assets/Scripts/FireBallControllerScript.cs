using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallControllerScript : MonoBehaviour
{
    public bool chaged = true;
    [SerializeField] private Transform fireBallSpawnPoint;
    [SerializeField] private GameObject fireBall;
    [SerializeField] private float fireBallSpeed = 400;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (chaged) {
                if (fireBall != null && fireBallSpawnPoint != null)
                {
                    GameObject newFireBall = Instantiate(fireBall, fireBallSpawnPoint.position, fireBallSpawnPoint.rotation);
                    newFireBall.GetComponent<Rigidbody>().AddForce(fireBallSpawnPoint.forward * fireBallSpeed);
                }
                Debug.Log( name + " Pew");
                //chaged = false;
            }
        }
    }
}
