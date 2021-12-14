using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Controlls : MonoBehaviour
{
    [SerializeField] Transform level;

    Vector2 dragVector;
    bool clicked = false;

    [SerializeField] [Range(0, 20)] float sensitivity = 10f;

    public void OnDrag(InputAction.CallbackContext context)
    {
        dragVector = context.ReadValue<Vector2>();
    }

    public void OnClick(InputAction.CallbackContext context)
    {
        clicked = context.ReadValueAsButton();
    }

    void Update()
    {
        if (clicked)
        {
            level.Rotate(0, -dragVector.x * sensitivity * Time.deltaTime, 0);
        }
    }
}
