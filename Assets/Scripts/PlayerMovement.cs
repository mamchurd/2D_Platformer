using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _horizontalSpeed;
    [SerializeField] private float _jumpForce;

    private float _verticalSpeed;
    private Rigidbody2D _rigidbody2D;
    private Animator _animator;

    public bool IsLanded => Math.Abs(_verticalSpeed) <= 0.01f;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _horizontalSpeed = 5f;
        _jumpForce = 6f;
    }

    private void FixedUpdate()
    {
        _verticalSpeed = _rigidbody2D.velocity.y;
        _animator.SetBool("IsLanded", IsLanded);
        _animator.SetFloat("VerticalSpeed", _verticalSpeed);      
    }

    public void ChangeRotation(Vector2 direction)
    {
        Vector3 currentScale = transform.localScale;
        currentScale.x = direction.x == 0 ? currentScale.x : direction.x;
        transform.localScale = currentScale;
    }

    public void Jump()
    {
        _rigidbody2D.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
    }

    public void Move(Vector2 direction)
    {
        _animator.SetFloat("HorizontalSpeed", Math.Abs(direction.x));
        float scaleMoveSpeed = _horizontalSpeed * Time.deltaTime;
        Vector3 moveDirection = new Vector3(direction.x, 0, 0);
        transform.position += moveDirection * scaleMoveSpeed;
    }

}
