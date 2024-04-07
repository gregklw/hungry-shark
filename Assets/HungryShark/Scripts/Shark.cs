using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shark : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private Camera _camera;
    private Vector2 _currentSmoothedPosition;
    private Vector2 _latestTravelPosition;
    private float _speedFactor = 0.5f;
    public float SpeedFactor { 
        get => _speedFactor; 
        set 
        {
            if (value > 2.0f) _speedFactor = 2.0f;
            else 
            {
                _speedFactor = Mathf.Clamp(value, 0.35f, 2.0f);
            }
        }
    }
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _camera = Camera.main;
    }

    void FixedUpdate()
    {
        Debug.Log(_rigidbody2D.velocity);
        Vector2 smoothedPosition = Vector2.SmoothDamp(transform.position, _latestTravelPosition, ref _currentSmoothedPosition, _speedFactor);
        _camera.transform.position = new Vector3(smoothedPosition.x, smoothedPosition.y, -10);
        _rigidbody2D.MovePosition(smoothedPosition);
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            _latestTravelPosition = _camera.ScreenToWorldPoint(Input.mousePosition);
        }
    }
}
