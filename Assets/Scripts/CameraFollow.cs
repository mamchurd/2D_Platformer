using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _background;
    [SerializeField] private PlayerCollision _player;

    private Camera _camera;
    private float _cameraVerticalExtent;
    private float _cameraHorizontallExtent;

    private void Awake()
    {
        _camera = GetComponent<Camera>();

        _cameraVerticalExtent = _camera.orthographicSize;
        _cameraHorizontallExtent = _camera.orthographicSize * _camera.aspect;

        transform.position = new Vector3(_player.transform.position.x, _player.transform.position.y, transform.position.z);
    }

    private void Update()
    {
        float camPositionX = Mathf.Clamp(_player.transform.position.x, _background.bounds.min.x + _cameraHorizontallExtent, _background.bounds.max.x - _cameraHorizontallExtent);
        float camPositionY = Mathf.Clamp(_player.transform.position.y, _background.bounds.min.y + _cameraVerticalExtent, _background.bounds.max.y - _cameraVerticalExtent);

        Vector3 cameraPosition = new Vector3(camPositionX, camPositionY, transform.position.z);

        Vector3 position = Vector3.Lerp(transform.position, cameraPosition, 8f * Time.deltaTime);

        transform.position = position;
    }
}
