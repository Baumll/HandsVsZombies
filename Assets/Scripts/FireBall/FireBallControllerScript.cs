using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class FireBallControllerScript : MonoBehaviour
{
    enum Direction {Left, Right};

    private bool fireRightBlock = false;
    private bool fireLeftBlock = false;
    private bool fireRightPressed = false;
    private bool fireLeftPressed = false;
    [SerializeField] private Direction handside;
    [SerializeField] private Transform fireBallSpawnPoint;
    [SerializeField] private GameObject fireBall;
    [SerializeField] private float fireBallSpeed = 200;
    [SerializeField] private SkinnedMeshRenderer skinnedMeshRenderer;
    [SerializeField] private Material fireMaterial;
    private Material passiveMaterial;

    // controll Zeugs
    void Start()
    {
        NewControls newControls = new NewControls();
        newControls.Fireball.Enable();
        newControls.Fireball.TriggerLeft.started += TriggerLeftOnstarted;
        newControls.Fireball.TriggerLeft.canceled += TriggerLeftOncanceled;
        newControls.Fireball.TriggerRight.started += TriggerRightOnstarted;
        newControls.Fireball.TriggerRight.canceled += TriggerRightOncanceled;
        newControls.Fireball.FireRight.started += FireRight_started;
        newControls.Fireball.FireRight.canceled += FireRight_canceled;
        newControls.Fireball.FireLeft.started += FireLeft_started;
        newControls.Fireball.FireLeft.canceled += FireLeft_canceled;

        passiveMaterial = skinnedMeshRenderer.material;
    }

    private void FireRight_canceled(InputAction.CallbackContext obj)
    {
        fireRightPressed = false;
    }

    private void FireLeft_started(InputAction.CallbackContext obj)
    {
        fireLeftPressed = true;
    }

    private void FireLeft_canceled(InputAction.CallbackContext obj)
    {
        fireLeftPressed = false;
    }

    private void FireRight_started(InputAction.CallbackContext obj)
    {
        fireRightPressed = true;
    }

    private void TriggerRightOncanceled(InputAction.CallbackContext obj)
    {
        fireRightBlock = false;
    }

    private void TriggerRightOnstarted(InputAction.CallbackContext obj)
    {
        fireRightBlock = true;
    }

    private void TriggerLeftOncanceled(InputAction.CallbackContext obj)
    {
        fireLeftBlock = false;
    }

    private void TriggerLeftOnstarted(InputAction.CallbackContext obj)
    {
        fireLeftBlock = false;
    }

    // Feuert Den Feuerball ab
    void Update()
    {
        if(GameManager.instance != null)
        {
            if (handside == Direction.Left)
            {
                if (GameManager.instance.leftCanShoot)
                {
                    skinnedMeshRenderer.material = fireMaterial;
                }
                else
                {
                    skinnedMeshRenderer.material = passiveMaterial;
                }
            }

            if (handside == Direction.Right)
            {
                if (GameManager.instance.rightCanShoot)
                {
                    skinnedMeshRenderer.material = fireMaterial;
                }
                else
                {
                    skinnedMeshRenderer.material = passiveMaterial;
                }
            }

            bool firering = false;
            if (handside == Direction.Left)
            {
                if (!fireLeftBlock && fireLeftPressed)
                {
                    if (GameManager.instance.leftCanShoot)
                    {
                        firering = true;
                    }
                }
            }
            else
            {
                if (!fireRightBlock && fireRightPressed)
                {
                    if (GameManager.instance.rightCanShoot)
                    {
                        firering = true;
                    }
                }
            }
            if (firering)
            {
                if (fireBall != null && fireBallSpawnPoint != null)
                {
                    GameObject newFireBall = Instantiate(fireBall, fireBallSpawnPoint.position, fireBallSpawnPoint.rotation);
                    newFireBall.GetComponent<Rigidbody>().AddForce(fireBallSpawnPoint.forward * fireBallSpeed);
                    if (handside == Direction.Left)
                    {
                        GameManager.instance.leftCanShoot = false;
                    }
                    else
                    {
                        GameManager.instance.rightCanShoot = false;
                    }
                }
                Debug.Log(name + " Pew");
                //chaged = false;
            }
        }
    }
        
}
