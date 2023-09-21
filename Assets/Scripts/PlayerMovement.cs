using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _forceMagnitude;
    [SerializeField] private float _maxVelocity;

    private Camera _mainCamera;
    private Rigidbody _rb;

    private Vector3 _movementDirection;

    private void Start()
    {
        _mainCamera = Camera.main;
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if(Touchscreen.current.primaryTouch.press.isPressed)
        {
            Vector2 touchPosition = Touchscreen.current.primaryTouch.position.ReadValue();

            Vector3 worldPosition = _mainCamera.ScreenToWorldPoint(touchPosition);

            _movementDirection = transform.position - worldPosition;
            _movementDirection.z = 0;
            _movementDirection.Normalize();
        }
        else
        {
            _movementDirection = Vector3.zero;
        }
    }

    private void FixedUpdate()
    {
        if(_movementDirection == Vector3.zero)
        {
            return;
        }

        _rb.AddForce(_movementDirection * _forceMagnitude * Time.deltaTime, ForceMode.Force);

        _rb.velocity = Vector3.ClampMagnitude(_rb.velocity, _maxVelocity);

    }
}
