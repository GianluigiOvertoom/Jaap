using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private InputMaster inputMaster;
    private Rigidbody2D rb;
    private Animator anim;
    private Vector2 moveInput;

    [SerializeField]
    private float speed = 10f; 

    private void Awake()
    {
        inputMaster = new InputMaster();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
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

        anim.SetFloat("MovementX", moveInput.x);
        anim.SetFloat("MovementY", moveInput.y);

        if (moveInput.x == 1 || moveInput.x == -1 || moveInput.y == 1 || moveInput.y == -1)
        {
            anim.SetFloat("LastMovementX", moveInput.x);
            anim.SetFloat("LastMovementY", moveInput.y);
        }
    }
}
