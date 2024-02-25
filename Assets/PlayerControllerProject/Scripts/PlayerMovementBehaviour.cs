using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementBehaviour : MonoBehaviour
{

    private Vector3 movementDirection;
    public Camera gameplayCamera;


    private Rigidbody playerRigidbody;


    // Update is called once per frame
    void Update()
    {
        
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
}
