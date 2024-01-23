using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class FireBallControllerScript : MonoBehaviour
{
    enum Direction {Left, Right};

    private bool fireRight = false;
    private bool fireLeft = false;
    [SerializeField] private Direction handside;
    public bool chaged = true;
    [SerializeField] private Transform fireBallSpawnPoint;
    [SerializeField] private GameObject fireBall;
    [SerializeField] private float fireBallSpeed = 400;


    // Start is called before the first frame update
    void Start()
    {
        NewControls newControls = new NewControls();
        newControls.Fireball.Enable();
        newControls.Fireball.TriggerLeft.started += TriggerLeftOnstarted;
        newControls.Fireball.TriggerLeft.canceled += TriggerLeftOncanceled;
        newControls.Fireball.TriggerRight.started += TriggerRightOnstarted;
        newControls.Fireball.TriggerRight.canceled += TriggerRightOncanceled;
    }

    private void TriggerRightOncanceled(InputAction.CallbackContext obj)
    {
        fireRight = false;
    }

    private void TriggerRightOnstarted(InputAction.CallbackContext obj)
    {
        fireRight = true;
    }

    private void TriggerLeftOncanceled(InputAction.CallbackContext obj)
    {
        fireLeft = false;
    }

    private void TriggerLeftOnstarted(InputAction.CallbackContext obj)
    {
        fireLeft = false;
    }

    // Update is called once per frame
    void Update()
    {
        bool firering = false;
        if (handside == Direction.Left && fireLeft)
        {
            
        }
        else
        {
            if (Input.GetButtonDown("Fire1") && !Input.GetButtonDown("TriggerRight"))
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
