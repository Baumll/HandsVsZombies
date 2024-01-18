using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallControllerScript : MonoBehaviour
{
    enum Direction {Left, Right};

    [SerializeField] private Direction handside;
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
        bool firering = false;
        if (handside == Direction.Left)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                firering = true;
            }
        }
        else
        {
            if (Input.GetButtonDown("Fire2"))
            {
                firering = true;
            }
        }
        if (chaged && firering) {
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
