using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;

    [SerializeField] private float knockbackX;
    [SerializeField] private float knockvackY;

    private Animator _animator;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        knockbackX = 6;
        knockvackY = 10;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.transform.TryGetComponent<EnemyMovement>(out EnemyMovement enemyMovement))
        {
            float knockbackDirection = (transform.position - collision.transform.position).normalized.x;

            _rigidbody2D.velocity = new Vector2(knockbackDirection * knockbackX, knockvackY);

            _animator.SetTrigger("Hit");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<EnemyMovement>(out EnemyMovement enemyMovement))
        {

            _rigidbody2D.velocity = new Vector2(0, knockvackY);
        }
    }
}
