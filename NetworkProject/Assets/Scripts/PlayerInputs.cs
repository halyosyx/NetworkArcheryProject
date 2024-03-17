using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerInputs : MonoBehaviour
{
    private PlayerControls playerControls;
    private Vector2 movementInput;
    public Vector2 MovementVector => movementInput;

    private void OnEnable()
    {
        if (playerControls == null)
        {
            playerControls = new PlayerControls();
        }


        playerControls.PlayerMovement.Movement.performed += i => movementInput = i.ReadValue<Vector2>();
        playerControls.PlayerMovement.Movement.canceled += i => movementInput = Vector2.zero;
        playerControls.Enable();
    }

    private void OnDisable()
    {
        if (playerControls != null)
        {
            playerControls.Disable();
        }
    }

}
