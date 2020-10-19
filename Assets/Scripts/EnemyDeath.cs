using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    [SerializeField] private GameObject _deathAnimation;
    [SerializeField] private int _gemReward;

    private GemSpawner _gemSpawner;

    private void Awake()
    {
        _gemSpawner = GetComponent<GemSpawner>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.TryGetComponent<EnemySmasher>(out EnemySmasher enemySmasher))
        {
            Vector3 currentPosition = transform.position;

            var anim = Instantiate(_deathAnimation, currentPosition, Quaternion.identity);

            anim.GetComponent<SpriteRenderer>().sortingOrder = 5;

            Destroy(gameObject);
            Destroy(anim, 0.6f);

            _gemSpawner.SpawnGems(_gemReward, transform.position);

        }
    }
}
