using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class PlayerFiring : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform crosshair;
    [SerializeField] private float bulletSpeed = 5;
    private Rigidbody2D bulletRb;
    private BoxCollider2D boxCol;
    private PlayerInput playerInput;
    private InputAction mouseAim;    
    private InputAction fire;
    private InputAction ads;

    private Vector2 mouseCoords;
    private bool isFiring;

    private void Awake() 
    {
        bulletRb = bullet.GetComponent<Rigidbody2D>();
        boxCol = bullet.GetComponent<BoxCollider2D>();
        playerInput = GetComponent<PlayerInput>();
        mouseAim = playerInput.actions["Aim"];
        fire = playerInput.actions["Fire"];
    }

    // Update is called once per frame
    void Update()
    {
        //Grab mouse input
        mouseCoords = mouseAim.ReadValue<Vector2>();

        //Keep crosshair at mouse position
        Vector2 mouseWorldPos = Camera.main.ScreenToWorldPoint(mouseCoords);
        crosshair.position = mouseWorldPos;

        if(fire.triggered)
        {
            //Get the direction of where we wanna fire
            Vector2 dir = crosshair.position - transform.position;
            Quaternion bulletRot = Quaternion.LookRotation(Vector3.forward, Quaternion.Euler(0,0,90) * dir);
            GameObject newBullet = Instantiate(bullet, transform.position, bulletRot);
            newBullet.GetComponent<Rigidbody2D>().velocity = dir.normalized * bulletSpeed;
        }
    }

    private void FixedUpdate() 
    {
        
    }
}
