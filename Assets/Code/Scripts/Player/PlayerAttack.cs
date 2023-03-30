using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    private InputMaster inputMaster;
    private Animator anim;
    private Vector2 moveInput;

    private void Awake()
    {
        inputMaster = new InputMaster();
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
        Vector2 moveInput = inputMaster.PlayerInput.Attack.ReadValue<Vector2>();

        anim.SetFloat("LastMovementX", moveInput.x);
        anim.SetFloat("LastMovementY", moveInput.y);
    }
}
