using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    public static PlayerInput Instance;

    public Vector3 movementInput;

    public bool isMoving;

    private void Awake()
    {
        if(Instance != null)
        {
            return;
        }

        Instance = this;

    }

    public void OnMovement(InputAction.CallbackContext value)
    {
        if(value.performed)
        {
            Vector3 movementValue = value.ReadValue<Vector2>();
            movementInput = new Vector3(movementValue.x, 0f, movementValue.y);
            isMoving = true;
            return;
        }
        movementInput = Vector3.zero;
        isMoving = false;
    }
}
