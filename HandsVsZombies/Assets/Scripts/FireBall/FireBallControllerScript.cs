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
    [SerializeField] private Transform fireBallSpawnPoint;
    [SerializeField] private GameObject fireBall;
    [SerializeField] private float fireBallSpeed = 400;
    [SerializeField] private SkinnedMeshRenderer skinnedMeshRenderer;
    [SerializeField] private Material fireMaterial;
    private Material passiveMaterial;

    // Start is called before the first frame update
    void Start()
    {
        NewControls newControls = new NewControls();
        newControls.Fireball.Enable();
        newControls.Fireball.TriggerLeft.started += TriggerLeftOnstarted;
        newControls.Fireball.TriggerLeft.canceled += TriggerLeftOncanceled;
        newControls.Fireball.TriggerRight.started += TriggerRightOnstarted;
        newControls.Fireball.TriggerRight.canceled += TriggerRightOncanceled;

        passiveMaterial = skinnedMeshRenderer.material;
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
            if (handside == Direction.Left && fireLeft)
            {
                if (Input.GetButtonDown("Fire2") && !Input.GetButtonDown("TriggerLeft"))
                {
                    if (GameManager.instance.leftCanShoot)
                    {
                        firering = true;
                    }
                }
            }
            else
            {
                if (Input.GetButtonDown("Fire1") && !Input.GetButtonDown("TriggerRight"))
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
