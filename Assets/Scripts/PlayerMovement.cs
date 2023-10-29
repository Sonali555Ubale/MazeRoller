using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    private PlayerInputActions inputActions;
    private SpriteRenderer sprite;
    private Animator animator;

    private float dirX = 0f;
    private float moveSpeed = 7f;
   


    private void Awake()
    {
        inputActions = new PlayerInputActions();
    }

    private void OnEnable()
    {
        inputActions.Player.Movement.Enable();
        
    }


    private void FixedUpdate()
    {
        CheckforMovementInput();
    }

    private void CheckforMovementInput() => OnMove(inputActions.Player.Movement.ReadValue<float>());

    private void OnDisable()
    {
        inputActions.Player.Movement.Disable();
        
    }


    public void OnMove(float context)
    {
        dirX = context;
        Debug.Log(context);
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
        
    }

    public void Start()
    {
        rb = GetComponent<Rigidbody>();
       
    }
   

    

   
}
