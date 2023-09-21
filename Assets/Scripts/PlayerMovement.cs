using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Camera _mainCamera;

    private void Start()
    {
        _mainCamera = Camera.main;
    }

    private void Update()
    {
        if(Touchscreen.current.primaryTouch.press.isPressed)
        {
            Vector2 touchPosition = Touchscreen.current.primaryTouch.position.ReadValue();

            Debug.Log(touchPosition);

            Vector3 worldPosition = _mainCamera.ScreenToViewportPoint(touchPosition);

            Debug.Log(worldPosition);
        }
    }
}
