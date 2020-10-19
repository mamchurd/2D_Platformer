using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour, IMovable
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;

    private float _verticalSpeed;

    public bool IsLanded => _verticalSpeed == 0;

    public void ChangeRotation(Vector2 direction)
    {
        Vector3 currentScale = transform.localScale;
        currentScale.x = direction.x == 0 ? currentScale.x : direction.x;
        transform.localScale = currentScale;
    }

    public void Jump()
    {

    }

    public void Move(Vector2 direction)
    {
        transform.position = Vector3.MoveTowards(transform.position, direction, _speed * Time.deltaTime);
    }

}
