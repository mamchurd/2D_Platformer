using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patroling : MonoBehaviour
{
    [SerializeField] private Transform _path;

    private Transform[] _points;
    private EnemyMovement _movable;
    private int _currentPoint;

    private void Start()
    {
        _movable = GetComponent<EnemyMovement>();

        _currentPoint = 0;
        _points = new Transform[_path.childCount];

        for (int i = 0; i < _path.childCount; i++)
        {
            _points[i] = _path.GetChild(i);
        }
    }

    private void Update()
    {
        Transform target = _points[_currentPoint];

        _movable.ChangeRotation((transform.position - target.position).normalized);

        Vector2 direction = target.position;

        _movable.Move(direction);

        if (transform.position == target.position)
        {
            _currentPoint++;

            if (_currentPoint == _points.Length)
                _currentPoint = 0;
        }
    }
}
