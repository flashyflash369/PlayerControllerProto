using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementBehaviour : MonoBehaviour
{

    private Vector3 movementDirection;
    public Camera gameplayCamera;


    private Rigidbody playerRigidbody;
    public float moveSpeed = 7f;
    public float turnSpeed = 7f;


    public float speedFactor = 0.0001f;
    public float movementSmoothingValue = 7f;

    private void Awake()
    {
        playerRigidbody = this.GetComponent<Rigidbody>();
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        SmoothMovementInput(PlayerInput.Instance.movementInput);
        TurnPlayer();
        MovePlayer();
       
    }

    //Function to Move the Player via Rigidbody
    private void MovePlayer()
    {
        Vector3 direction = GetCameraDirection(movementDirection) * moveSpeed * Time.deltaTime;
        playerRigidbody.MovePosition(this.transform.position + direction);
    }

    private void TurnPlayer()
    {
        if(movementDirection.sqrMagnitude > speedFactor)
        {
            Quaternion targetRotation = Quaternion.LookRotation(GetCameraDirection(movementDirection));
            Quaternion rotation = Quaternion.Slerp(playerRigidbody.rotation, targetRotation, turnSpeed*Time.deltaTime);

            playerRigidbody.MoveRotation(rotation);
        }
    }


    //Get Forward direction of the player in Regard of the Camera
    private Vector3 GetCameraDirection(Vector3 direction)
    {
        Vector3 cameraForward = gameplayCamera.transform.forward;
        Vector3 cameraRight = gameplayCamera.transform.right;

        cameraForward.y = 0f;
        cameraRight.y = 0f;

        return cameraForward * direction.z + cameraRight * direction.x;
    }

    private void SmoothMovementInput(Vector3 movementInput)
    {
        movementDirection = Vector3.Lerp(movementDirection, movementInput, movementSmoothingValue);
    }

}
