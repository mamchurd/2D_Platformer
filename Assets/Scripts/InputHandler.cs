using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{

    private IMovable _movable;
    private Vector2 _moveDirection;

    private void Awake()
    {
        _movable = GetComponent<IMovable>();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        _moveDirection = context.ReadValue<Vector2>();
        _movable.ChangeRotation(_moveDirection);
    }

    public void OnCrouch(InputAction.CallbackContext context)
    {
        GetComponent<Animator>().SetBool("Crouch", context.ReadValueAsButton());
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (_movable.IsLanded)
        {
            _movable.Jump();
        }
    }

    private void Update()
    {
        _movable.Move(_moveDirection);
    }

}
