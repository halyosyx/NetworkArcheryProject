using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 1.5f;
    [SerializeField] private float turnSpeed = 1.5f;

    private PlayerInputs playerInputs;
    private Rigidbody playerRigidBody;
    private Vector3 playerVelocity;

    //Find a better solution
    private Transform cameraObj;
    private Vector3 facingMovementDirection;

    void Start()
    {
        playerInputs = GetComponent<PlayerInputs>();
        playerRigidBody = GetComponent<Rigidbody>();
        cameraObj = Camera.main.transform;
    }

    private void FixedUpdate()
    {
        Movement();
    }

    private void Movement()
    {
        facingMovementDirection.y = 0;

        //Movement by direction;
        Vector3 forwardMovement = cameraObj.forward * playerInputs.MovementVector.y;
        Vector3 sideMovement = cameraObj.right * playerInputs.MovementVector.x;
        facingMovementDirection = (forwardMovement + sideMovement).normalized;
        playerVelocity = facingMovementDirection * movementSpeed;

        //Facing Direction;
        Vector3 rotateDirection = facingMovementDirection;

        if (rotateDirection == Vector3.zero)
        {
            rotateDirection = transform.forward;
        }

        Quaternion rotation = Quaternion.LookRotation(rotateDirection);

        playerRigidBody.velocity = playerVelocity;
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, turnSpeed * Time.deltaTime);
    }
}
