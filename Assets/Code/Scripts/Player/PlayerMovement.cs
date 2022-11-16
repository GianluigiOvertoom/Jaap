using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private InputMaster inputMaster;
    private Rigidbody2D rb;

    [SerializeField]
    private float speed = 10f; 


    private void Awake()
    {
        inputMaster = new InputMaster();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        inputMaster.Enable();
    }

    private void OnDisable()
    {
        inputMaster.Disable();
    }

    private void FixedUpdate()
    {
        Vector2 moveInput = inputMaster.PlayerInput.Movement.ReadValue<Vector2>();
        rb.velocity = moveInput * speed;
    }
}
