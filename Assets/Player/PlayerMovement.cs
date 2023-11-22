using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private CapsuleCollider2D capCol;
    private PlayerInput playerInput;

    //Store controls
    private InputAction movin;

    //Movement stuff
    private Vector2 rawMoveInput;
    private Vector2 smoothedMoveInput;
    private Vector2 currSmoothInput;
    [SerializeField] private float smoothInputAccel = .5f;
    [SerializeField] private float moveSpeed = 5f;
    private Vector2 force2apply;
    [SerializeField] private float forceDampening = 1.2f;

    private void Awake() 
    {
        rb = GetComponent<Rigidbody2D>();
        capCol = GetComponent<CapsuleCollider2D>();
        playerInput = GetComponent<PlayerInput>();
        movin = playerInput.actions["Move"];
    }

    // Update is called once per frame
    void Update()
    {
        //Grab inputs
        rawMoveInput = movin.ReadValue<Vector2>();
        smoothedMoveInput = Vector2.SmoothDamp(smoothedMoveInput, rawMoveInput, ref currSmoothInput, smoothInputAccel);
    }

    void FixedUpdate() 
    {
        Vector2 force = smoothedMoveInput * moveSpeed;
        force += force2apply;
        force2apply /= forceDampening;
        if(Mathf.Abs(force2apply.x) <= 0.01f && Mathf.Abs(force2apply.y) <= 0.01f)
            force2apply = Vector2.zero;
        //Apply movement
        rb.velocity = force;
    }
}
