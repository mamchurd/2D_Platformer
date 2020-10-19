using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _gem;

    private float _spawnForce;

    private void Awake()
    {
        _spawnForce = 8;    
    }

    public void SpawnGems(int count, Vector3 position)
    {
        for (int i = 0; i < count; i++)
        {
            SpawnGem(position);
        }
    }

    private void SpawnGem(Vector3 position)
    {

        GameObject _spawnedGem = Instantiate(_gem, position, Quaternion.identity);

        Rigidbody2D rigidbody = _spawnedGem.GetComponent<Rigidbody2D>();

        rigidbody.AddForce(new Vector2(Random.Range(-5, 5), _spawnForce), ForceMode2D.Impulse);

    }
}
