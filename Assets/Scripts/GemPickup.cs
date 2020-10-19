using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]

public class GemPickup : MonoBehaviour
{
    private Animator _animator;
    private Rigidbody2D _rigidbody;
    private BoxCollider2D _boxCollider;
    private float _timeToDestroy;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _boxCollider = GetComponent<BoxCollider2D>();
        _timeToDestroy = 0.4f;
    }

    private void Update()
    {
        if (_rigidbody.velocity.y == 0)
        {
            _rigidbody.velocity = new Vector2(0, 0);
            _rigidbody.bodyType = RigidbodyType2D.Kinematic;
            _boxCollider.isTrigger = true;
        }    
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.TryGetComponent<PlayerCollision>(out PlayerCollision player))
        {
            _animator.SetTrigger("Pickup");
            Destroy(_animator.gameObject, _timeToDestroy);
        }
        
    }
}
